using System;
using System.Collections.Generic;
using CesarBmx.Shared.Application.Responses;

namespace CesarBmx.Shared.Application.FakeResponses
{
    public static class FakeAudit
    {
        public static AuditLog GetFake_Add_Indicator()
        {
            return new AuditLog
            {              
                LogId = Guid.NewGuid(),
                Action = "Add",
                Entity = "Indicator",
                EntityId = "master_price",
                Time = DateTime.Now,
                Json = "{}"
            };
        }
        public static List<AuditLog> GetFake_List()
        {
            return new List<AuditLog>
            {
                GetFake_Add_Indicator()
            };
        }
    }
}
