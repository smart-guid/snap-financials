using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Snap.Financials.Infrastructure.Database.Models;
using Snap.Financials.Models;
using Snap.Financials.Repositories;

namespace Snap.Financials.Infrastructure.Database;

public class SqlRepository : ICompanyInfoRepository, ICustomerRepository, IInvoiceRepository
{
    private readonly DatabaseContext _database;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;


    public SqlRepository(IUserRepository userRepository, DatabaseContext database, IMapper mapper, ILogger<SqlRepository> logger)
    {
        _database = database;
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    #region Company Info

    public async Task<CompanyInfoModel> CreateCompanyInfoAsync(CompanyInfoModel model, CancellationToken cancellationToken)
    {
        await DeleteCompanyInfo(cancellationToken);

        var entity = _mapper.Map<CompanyInfo>(model);
        entity.UserId = _userRepository.GetCurrentUserId();
        entity.DateCreated = DateTime.UtcNow;
        entity.DateModified = DateTime.UtcNow;
        entity.Id = Guid.NewGuid();

        _database.CompanyInfo.Add(entity);

        await _database.SaveChangesAsync(cancellationToken);

        var result = await GetCompanyInfoAsync(cancellationToken);

        return result;
    }

    public async Task<bool> UpdateCompanyInfoAsync(CompanyInfoModel model, CancellationToken cancellationToken)
    {
        var entity = await _database.CompanyInfo.FirstOrDefaultAsync(w => w.Id == model.Id);

        if (entity != null)
        {
            entity.Name = model.Name;
            entity.Email = model.Email;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Province = model.Province;
            entity.Country = model.Country;
            entity.LogoUrl = model.LogoUrl;
            entity.DateModified = DateTime.UtcNow;

            _database.Update(entity);
            await _database.SaveChangesAsync(cancellationToken);
        }

        return (entity != null);
    }

    public async Task<CompanyInfoModel> GetCompanyInfoAsync(CancellationToken cancellationToken)
    {
        var result = await _database.CompanyInfo.FirstOrDefaultAsync(w => w.UserId == _userRepository.GetCurrentUserId(), cancellationToken);

        return _mapper.Map<CompanyInfoModel>(result);
    }

    private async Task DeleteCompanyInfo(CancellationToken cancellationToken)
    {
        var result = await _database.CompanyInfo.FirstOrDefaultAsync(w => w.UserId == _userRepository.GetCurrentUserId(), cancellationToken);

        if (result != null)
        {
            _database.CompanyInfo.Remove(result);

            await _database.SaveChangesAsync(cancellationToken);
        }
    }

    #endregion

    #region Customers

    public async Task<CustomerModel> CreateCustomerAsync(CustomerModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Customer>(model);
        entity.UserId = _userRepository.GetCurrentUserId();
        entity.DateCreated = DateTime.UtcNow;
        entity.DateModified = DateTime.UtcNow;
        entity.Id = Guid.NewGuid();

        _database.Customers.Add(entity);

        await _database.SaveChangesAsync(cancellationToken);

        var result = await GetCustomerByIdAsync(entity.Id, cancellationToken);

        return result;
    }

    public async Task<bool> UpdateCustomerAsync(CustomerModel model, CancellationToken cancellationToken)
    {
        var entity = await _database.Customers.FirstOrDefaultAsync(w => w.Id == model.Id);

        if (entity != null)
        {
            entity.Name = model.Name;
            entity.Email = model.Email;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Province = model.Province;
            entity.Country = model.Country;
            entity.DateModified = DateTime.UtcNow;

            _database.Update(entity);
            await _database.SaveChangesAsync(cancellationToken);
        }

        return (entity != null);
    }

    public async Task<CustomerModel> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _database.Customers.FirstOrDefaultAsync(w => w.UserId == _userRepository.GetCurrentUserId() && w.Id == id, cancellationToken);

        return _mapper.Map<CustomerModel>(result);
    }

    public async Task<IList<CustomerModel>> GetCustomersAsync(CancellationToken cancellationToken)
    {
        var result = await _database.Customers.Where(w => w.UserId == _userRepository.GetCurrentUserId()).OrderBy(o => o.Name).AsNoTracking().ToListAsync(cancellationToken);

        return _mapper.Map<IList<CustomerModel>>(result);
    }

    #endregion

    #region Invoices

    public async Task<InvoiceModel> CreateInvoiceAsync(InvoiceModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Invoice>(model);
        entity.UserId = _userRepository.GetCurrentUserId();
        entity.DateCreated = DateTime.UtcNow;
        entity.DateModified = DateTime.UtcNow;
        entity.Id = Guid.NewGuid();

        _database.Invoices.Add(entity);

        await _database.SaveChangesAsync(cancellationToken);

        var result = await GetInvoiceByIdAsync(entity.Id, cancellationToken);

        return result;
    }

    public async Task<bool> UpdateInvoiceAsync(InvoiceModel model, CancellationToken cancellationToken)
    {
        var entity = await _database.Invoices.FirstOrDefaultAsync(w => w.Id == model.Id);

        if (entity != null)
        {
            //ToDo: add fields
            entity.DateModified = DateTime.UtcNow;

            _database.Update(entity);
            await _database.SaveChangesAsync(cancellationToken);
        }

        return (entity != null);
    }

    public async Task<InvoiceModel> GetInvoiceByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _database.Invoices.FirstOrDefaultAsync(w => w.UserId == _userRepository.GetCurrentUserId() && w.Id == id, cancellationToken);

        return _mapper.Map<InvoiceModel>(result);
    }

    public async Task<IList<InvoiceModel>> GetInvoicesAsync(CancellationToken cancellationToken)
    {
        var result = await _database.Invoices.Where(w => w.UserId == _userRepository.GetCurrentUserId()).OrderBy(o => o.DateCreated).AsNoTracking().ToListAsync(cancellationToken);

        return _mapper.Map<IList<InvoiceModel>>(result);
    }

    #endregion

    #region Invoice Lines


    public async Task CreateInvoiceLineAsync(Guid invoiceId, InvoiceLineModel model, CancellationToken cancellationToken)
    {

        var entity = _mapper.Map<InvoiceLine>(model);
        entity.UserId = _userRepository.GetCurrentUserId();
        entity.DateCreated = DateTime.UtcNow;
        entity.DateModified = DateTime.UtcNow;
        entity.Id = Guid.NewGuid();
        entity.InvoiceId = invoiceId;

        _database.InvoiceLines.Add(entity);

        await _database.SaveChangesAsync(cancellationToken);       
    }


    #endregion
}

