using Shared.DataTransferObjects;
using Shared.DataTrasferObjects;

namespace Service.Contracts;
public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);
    Task<CompanyDto> GetCompanyAsync(int companyId, bool trackChanges);
    Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);
    Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync
        (IEnumerable<CompanyForCreationDto> companyCollection);
    Task DeleteCompanyAsync(int companyId, bool trackChanges);
    Task UpdateCompanyAsync(int companyid, CompanyForUpdateDto companyForUpdate, bool trackChanges);
}
