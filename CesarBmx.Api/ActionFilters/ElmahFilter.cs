using ElmahCore;
using CesarBmx.Application.Exceptions;

namespace CesarBmx.Api.ActionFilters
{
    public class ElmahFilter :  IErrorFilter
    {
        public void OnErrorModuleFiltering(object sender, ExceptionFilterEventArgs args)
        {
            // We skip our custom exceptions
            if(args.Exception is DomainException)
                args.Dismiss();
        }
    }
}