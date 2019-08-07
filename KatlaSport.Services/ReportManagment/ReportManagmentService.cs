using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ReportsCatalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatlaSport.Services.ReportManagment
{
    internal sealed class ReportManagmentService : IReportService
    {
        IReportContext _context;

        public ReportManagmentService(IReportContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ReportRequest>> GetReportsAsync()
        {
            var dbreports = await _context.Reports.OrderBy(h => h.Id).ToListAsync();
            var reports = dbreports.Select(h => Mapper.Map<Report, ReportRequest>(h)).ToList();

            return reports;
        }

        public async Task<ReportRequest> GetReportAsync(int reportid)
        {
            var dbreports = await _context.Reports.Where(h => h.Id == reportid).ToArrayAsync();
            if (dbreports.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var report = Mapper.Map<Report, ReportRequest>(dbreports[0]);

            return report;
        }

        public async Task<Report> CreateReportAsync(ReportRequest createRequest)
        {
            var dbreports = await _context.Reports.Where(h => (h.AccountantId == createRequest.AccountantId && h.CompanyId == createRequest.CompanyId)).ToArrayAsync();
            if (dbreports.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var report = Mapper.Map<ReportRequest, Report>(createRequest);
            _context.Reports.Add(report);

            await _context.SaveChangesAsync();

            return report;
        }

        public async Task<Report> UpdateReportAsync(int reportid, ReportRequest updateRequest)
        {
            var dbreports = await _context.Reports.Where(h => (h.AccountantId == updateRequest.AccountantId && h.CompanyId == updateRequest.CompanyId)).ToArrayAsync();
            if (dbreports.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbreports = _context.Reports.Where(p => p.Id == reportid).ToArray();
            if (dbreports.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbreport = dbreports[0];

            dbreport.AccountantId = updateRequest.AccountantId;
            dbreport.CompanyId = updateRequest.CompanyId;
            await _context.SaveChangesAsync();

            return dbreport;
        }

        public async Task DeleteReportAsync(int reportid)
        {
            var dbreports = await _context.Reports.Where(p => p.Id == reportid).ToArrayAsync();
            if (dbreports.Length == 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            _context.Reports.Remove(dbreports[0]);
            await _context.SaveChangesAsync();
        }
    }
}
