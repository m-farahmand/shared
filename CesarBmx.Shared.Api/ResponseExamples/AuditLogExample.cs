using System.Collections.Generic;
using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class AuditLogExample : IExamplesProvider<AuditLog>
    {
        public AuditLog GetExamples()
        {
            return FakeAudit.GetFake_Add_Indicator();
        }
    }
    public class LogListResponseExample : IExamplesProvider<List<AuditLog>>
    {
        public List<AuditLog> GetExamples()
        {
            return FakeAudit.GetFake_List();
        }
    }
}