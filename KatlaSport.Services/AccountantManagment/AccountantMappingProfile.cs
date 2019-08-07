using AutoMapper;
using KatlaSport.DataAccess.AccountantCatalogue;

namespace KatlaSport.Services.AccountantManagment
{
    public sealed class AccountantMappingProfile : Profile
    {
        public AccountantMappingProfile()
        {
            CreateMap<AccountantRequest, Accountant>();
            CreateMap<Accountant, AccountantRequest>();
        }
    }
}
