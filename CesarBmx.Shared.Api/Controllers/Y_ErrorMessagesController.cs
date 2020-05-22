using System.Collections.Generic;
using CesarBmx.Shared.Application.ResponseBuilders;
using CesarBmx.Shared.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CesarBmx.Shared.Api.Controllers
{
    [SwaggerResponse(500, Type = typeof(InternalServerError))]
    [SwaggerResponse(401, Type = typeof(Unauthorized))]
    [SwaggerResponse(403, Type = typeof(Forbidden))]
    // ReSharper disable once InconsistentNaming
    [AllowAnonymous]
    public class Y_ErrorMessagesController : Controller
    {
        /// <summary>
        /// Get all error messages
        /// </summary>
        [HttpGet]
        [Route("api/error-messages")]
        [SwaggerResponse(200, Type = typeof(Dictionary<string,string[]>))]
        [SwaggerOperation(Tags = new[] { "Error messages" }, OperationId = "ErrorMessages_GetAllErrorMessages")]
        public IActionResult GetAllErrorMessages()
        {
            // Get error messages
            var errorMessages = ErrorMessageResponseBuilder.BuildErrorMessages();
            
            // Return
            return Ok(errorMessages);
        }
    }
}

