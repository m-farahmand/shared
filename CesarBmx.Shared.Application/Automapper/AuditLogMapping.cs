using AutoMapper;
using CesarBmx.Shared.Domain.Models;

namespace CesarBmx.Shared.Application.Automapper
{
    public class AuditLogMapping : Profile
    {
        public AuditLogMapping()
        {
            CreateMap<AuditLog, Responses.AuditLog>();
        }
    }
}
