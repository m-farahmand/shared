using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
                            var errorResponse = new BadRequest(nameof(Application.Messages.ErrorMessage.BadRequest), Application.Messages.ErrorMessage.BadRequest);
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

               
                var validationErrorsResponse = new List<ValidationError>();
                foreach (var error in errors)
                {
                    foreach (var value in error.Value)
                    {
                        // Handle DataAnotations Required
                        if (value.Contains("field is required"))
                        {
                            validationErrorsResponse.Add(new ValidationError(nameof(Application.Messages.ErrorMessage.Required), error.Key, Application.Messages.ErrorMessage.Required));
                        }
                        else // Handle fluent validations
                        {
                            var index = value.IndexOf(" ", StringComparison.Ordinal);
                            var code = value.Substring(0, index);
                            var message = value.Substring(index + 1);
                            validationErrorsResponse.Add(new ValidationError(code, error.Key, message));
                        }
                    }
                }
                var validationsResponse = new ValidationFailed(nameof(Application.Messages.ErrorMessage.ValidationFailed), Application.Messages.ErrorMessage.ValidationFailed, validationErrorsResponse);

                filterContext.Result = new ObjectResult(validationsResponse) { StatusCode = 422 };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}