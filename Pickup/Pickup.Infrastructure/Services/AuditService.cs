﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pickup.Application.Interfaces.Services;
using Pickup.Application.Models.Audit;
using Pickup.Application.Responses.Audit;
using Pickup.Infrastructure.Contexts;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Infrastructure.Services
{
    public class AuditService : IAuditService
    {
        private readonly BlazorHeroContext _context;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;
        private readonly IStringLocalizer<AuditService> _localizer;

        public AuditService(
            IMapper mapper,
            BlazorHeroContext context,
            IExcelService excelService,
            IStringLocalizer<AuditService> localizer)
        {
            _mapper = mapper;
            _context = context;
            _excelService = excelService;
            _localizer = localizer;
        }

        public async Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId)
        {
            var trails = await _context.AuditTrails.Where(a => a.UserId == userId).OrderByDescending(a => a.Id).Take(250).ToListAsync();
            var mappedLogs = _mapper.Map<List<AuditResponse>>(trails);
            return await Result<IEnumerable<AuditResponse>>.SuccessAsync(mappedLogs);
        }

        public async Task<string> ExportToExcelAsync(string userId)
        {
            var trails = await _context.AuditTrails.Where(x => x.UserId == userId)
                .OrderByDescending(a => a.DateTime).ToListAsync();
            var result = await _excelService.ExportAsync(trails, sheetName: _localizer["Audit trails"],
                mappers: new Dictionary<string, Func<Audit, object>>()
                {
                    { _localizer["Table Name"], item => item.TableName },
                    { _localizer["Type"], item => item.Type },
                    { _localizer["Date Time (Local)"], item => DateTime.SpecifyKind(item.DateTime, DateTimeKind.Utc).ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss") },
                    { _localizer["Date Time (UTC)"], item => item.DateTime.ToString("dd/MM/yyyy HH:mm:ss") },
                    { _localizer["Primary Key"], item => item.PrimaryKey },
                    { _localizer["Old Values"], item => item.OldValues },
                    { _localizer["New Values"], item => item.NewValues },
                });

            return result;
        }
    }
}