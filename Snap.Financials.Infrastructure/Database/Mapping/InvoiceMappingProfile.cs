using AutoMapper;
using Snap.Financials.Infrastructure.Database.Models;
using Snap.Financials.Models;

namespace Snap.Financials.Infrastructure.Database.Mapping;

internal class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        this.CreateMap<Invoice, InvoiceModel>().ReverseMap();

        this.CreateMap<InvoiceLine, InvoiceLineModel>().ReverseMap();
    }
}

