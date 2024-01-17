using AutoMapper;
using Snap.Financials.Infrastructure.Database.Models;
using Snap.Financials.Models;

namespace Snap.Financials.Infrastructure.Database.Mapping;

internal class CompanyInfoMappingProfile : Profile
{
    public CompanyInfoMappingProfile()
    {
        this.CreateMap<CompanyInfo, CompanyInfoModel>().ReverseMap();        
    }
}

