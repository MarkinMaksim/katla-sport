using AutoMapper;
using KatlaSport.DataAccess.CompanyCatalogue;

namespace KatlaSport.Services.CompanyManagment
{
    public sealed class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CompanyRequest, Company>();
            CreateMap<Company, CompanyRequest>();
        }
    }
}
