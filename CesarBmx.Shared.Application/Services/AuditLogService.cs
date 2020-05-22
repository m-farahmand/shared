﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CesarBmx.Shared.Application.Exceptions;
using CesarBmx.Shared.Application.Messages;
using CesarBmx.Shared.Persistence.Repositories;

namespace CesarBmx.Shared.Application.Services
{
    public class AuditLogService
    {
        private readonly IRepository<Domain.Models.AuditLog> _logRepository;
        private readonly IMapper _mapper;

        public AuditLogService(IRepository<Domain.Models.AuditLog> logRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        public async Task<List<Responses.AuditLog>> GetAuditLogs()
        {
            // Get all audit logs
            var logs = await _logRepository.GetAll();

            // Response
            var response = _mapper.Map<List<Responses.AuditLog>>(logs);

            // Return
            return response;
        }
        public async Task<Responses.AuditLog> GetAuditLog(Guid logId)
        {
            // Get audit log
            var auditLog = await _logRepository.GetSingle(logId);

            // Throw NotFound if the currency does not exist
            if (auditLog == null) throw new NotFoundException(AuditLogMessage.LogNotFound);

            // Response
            var response = _mapper.Map<Responses.AuditLog>(auditLog);

            // Return
            return response;
        }
    }
}
