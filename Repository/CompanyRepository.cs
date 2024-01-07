using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public sealed class CompanyRepository(RepositoryContext Context)
    : RepositoryBase<Company>(Context), ICompanyRepository
{
    public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges)
        => await FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToListAsync();

    public async Task<Company> GetCompanyAsync(int companyId, bool trackChanges)
        => await FindByCondition(company => company.Id == companyId, trackChanges)
        .SingleOrDefaultAsync();

    public void UpdateCompany(Company company) => Update(company);
    public void CreateCompany(Company company) => Create(company);
    public void DeleteCompany(Company company) => Delete(company);

}
