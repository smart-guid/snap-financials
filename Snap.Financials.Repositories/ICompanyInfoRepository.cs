using Snap.Financials.Models;

namespace Snap.Financials.Repositories;

public interface ICompanyInfoRepository
{
    Task<CompanyInfoModel> GetCompanyInfoAsync(CancellationToken cancellationToken);

    Task<CompanyInfoModel> CreateCompanyInfoAsync(CompanyInfoModel model, CancellationToken cancellationToken);

    Task<bool> UpdateCompanyInfoAsync(CompanyInfoModel model, CancellationToken cancellationToken);
}