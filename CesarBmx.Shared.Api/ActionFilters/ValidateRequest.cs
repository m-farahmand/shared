using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CesarBmx.Shared.Application.Messages;
using CesarBmx.Shared.Application.Responses;

namespace CesarBmx.Shared.Api.ActionFilters
{
    public class ValidateRequestAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                // 400 Bad Request
                foreach (var value in filterContext.ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        if (error.Exception != null || error.ErrorMessage.Contains("line ") && error.ErrorMessage.Contains("position "))
                        {
                            var errorResponse = new BadRequestResponse(nameof(ErrorMessage.BadRequest), ErrorMessage.BadRequest);
                            filterContext.Result = new ObjectResult(errorResponse) { StatusCode = 400 };
                            return;
                        }
                    }
                }

                // 422 Unprocessable Entity
                var errors = filterContext.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

               
                var validationErrorsResponse = new List<ValidationErrorResponse>();
                foreach (var error in errors)
                {
                    foreach (var value in error.Value)
                    {
                        // Handle DataAnotations Required
                        if (value.Contains("field is required"))
                        {
                            validationErrorsResponse.Add(new ValidationErrorResponse(nameof(ErrorMessage.Required), error.Key, ErrorMessage.Required));
                        }
                        else // Handle fluent validations
                        {
                            var index = value.IndexOf(" ", StringComparison.Ordinal);
                            var code = value.Substring(0, index);
                            var message = value.Substring(index + 1);
                            validationErrorsResponse.Add(new ValidationErrorResponse(code, error.Key, message));
                        }
                    }
                }
                var validationsResponse = new ValidationFailedResponse(nameof(ErrorMessage.ValidationFailed), ErrorMessage.ValidationFailed, validationErrorsResponse);

                filterContext.Result = new ObjectResult(validationsResponse) { StatusCode = 422 };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}