using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CesarBmx.Shared.Api.Configuration
{
    public static class FluentValidationConfigConfig
    {
        public static IMvcBuilder ConfigurePinnacleFluentValidation(this IMvcBuilder mvcBuilder, Assembly assembly)
        {
            mvcBuilder.AddFluentValidation(fv => fv
                .RegisterValidatorsFromAssembly(assembly)
                .RunDefaultMvcValidationAfterFluentValidationExecutes = true);
               

            return mvcBuilder;
        }
    }
}
