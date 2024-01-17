using AutoMapper;
using Snap.Financials.Infrastructure.Database.Models;
using Snap.Financials.Models;

namespace Snap.Financials.Infrastructure.Database.Mapping;

internal class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        this.CreateMap<Customer, CustomerModel>().ReverseMap();
    }
}

