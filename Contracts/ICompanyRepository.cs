using Entities.Models;

namespace Contracts;
public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
    Task<Company> GetCompanyAsync(int companyId, bool trackChanges);
    void CreateCompany(Company company);
    void DeleteCompany(Company company);
    void UpdateCompany(Company company);
}
