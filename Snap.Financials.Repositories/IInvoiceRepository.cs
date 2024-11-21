using Snap.Financials.Models;

namespace Snap.Financials.Repositories;

public interface IInvoiceRepository
{
    Task<IList<InvoiceModel>> GetInvoicesAsync(CancellationToken cancellationToken);
    Task<InvoiceModel> GetInvoiceByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<InvoiceModel> CreateInvoiceAsync(InvoiceModel model, CancellationToken cancellationToken);
    Task<bool> UpdateInvoiceAsync(InvoiceModel model, CancellationToken cancellationToken);


    Task CreateInvoiceLineAsync(Guid invoiceId, InvoiceLineModel model, CancellationToken cancellationToken);
}
