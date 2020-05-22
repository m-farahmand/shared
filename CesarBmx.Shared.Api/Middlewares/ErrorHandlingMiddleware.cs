using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CesarBmx.Shared.Application.Exceptions;
using CesarBmx.Shared.Application.Responses;
using CesarBmx.Shared.Logging.Extensions;
using ErrorMessage = CesarBmx.Shared.Application.Messages.ErrorMessage;

namespace CesarBmx.Shared.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Response
            Error errorResponse;
            switch (exception)
            {
                case UnauthorizedException _: // 401
                    var unauthorizedException = (UnauthorizedException)exception;
                    errorResponse = new Unauthorized(nameof(ErrorMessage.Unauthorized), unauthorizedException.Message);
                    break;
                case ForbiddenException _:    // 403
                    var forbiddenException = (ForbiddenException)exception;
                    errorResponse = new Forbidden(nameof(ErrorMessage.Forbidden), forbiddenException.Message);
                    break;
                case NotFoundException _:     // 404
                    var notFoundException = (NotFoundException)exception;
                    errorResponse = new NotFound(nameof(ErrorMessage.NotFound), notFoundException.Message);
                    break;
                case ConflictException _:     // 409
                    var conflictException = (ConflictException)exception;
                    errorResponse = new Conflict(nameof(ErrorMessage.Conflict), conflictException.Message);
                    break;
                default:                      // 500
                    errorResponse = new InternalServerError(nameof(ErrorMessage.InternalServerError), ErrorMessage.InternalServerError);
                    // Log error
                    _logger.LogSplunkError(exception);
                    break;
            }

            var response = JsonConvert.SerializeObject(errorResponse, Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() }
                });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.Status;
            return context.Response.WriteAsync(response);
        }
    }
}
