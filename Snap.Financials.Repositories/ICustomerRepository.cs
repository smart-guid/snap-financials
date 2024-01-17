using Snap.Financials.Models;

namespace Snap.Financials.Repositories;

public interface ICustomerRepository
{
    Task<IList<CustomerModel>> GetCustomersAsync(CancellationToken cancellationToken);

    Task<CustomerModel> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<CustomerModel> CreateCustomerAsync(CustomerModel model, CancellationToken cancellationToken);

    Task<bool> UpdateCustomerAsync(CustomerModel model, CancellationToken cancellationToken);

}
