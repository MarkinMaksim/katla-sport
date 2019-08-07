using System.Collections.Generic;
using System.Threading.Tasks;
using KatlaSport.DataAccess.ReportsCatalogue;

namespace KatlaSport.Services.ReportManagment
{
    public interface IReportService
    {
        Task<List<ReportRequest>> GetReportsAsync();

        Task<ReportRequest> GetReportAsync(int reportid);

        Task<Report> CreateReportAsync(ReportRequest createRequest);

        Task<Report> UpdateReportAsync(int reportid, ReportRequest updateRequest);

        Task DeleteReportAsync(int reportid);
    }
}
