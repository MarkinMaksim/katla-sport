using AutoMapper;
using KatlaSport.DataAccess.ReportsCatalogue;

namespace KatlaSport.Services.ReportManagment
{
    public sealed class ReportMappingProfile : Profile
    {

        public ReportMappingProfile()
        {
            CreateMap<ReportRequest, Report>();
            CreateMap<Report, ReportRequest>();
        }
    }
}
