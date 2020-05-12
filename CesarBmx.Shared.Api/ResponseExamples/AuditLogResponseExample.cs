using System.Collections.Generic;
using CesarBmx.Shared.Application.FakeResponses;
using CesarBmx.Shared.Application.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CesarBmx.Shared.Api.ResponseExamples
{
    public class AuditLogResponseExample : IExamplesProvider<AuditLogResponse>
    {
        public AuditLogResponse GetExamples()
        {
            return AuditLogFakeResponse.GetFake_Add_Indicator();
        }
    }
    public class LogListResponseExample : IExamplesProvider<List<AuditLogResponse>>
    {
        public List<AuditLogResponse> GetExamples()
        {
            return AuditLogFakeResponse.GetFake_List();
        }
    }
}