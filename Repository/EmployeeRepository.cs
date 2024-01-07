using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;
public sealed class EmployeeRepository(RepositoryContext Context)
    : RepositoryBase<Employee>(Context), IEmployeeRepository
{
    public void CreateEmployeeForCompany(int companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        Create(employee);
    }

    public async Task<Employee> GetEmployeeAsync(int companyId, int id, bool trackChanges)
        => await FindByCondition(e => e.CompanyId == companyId
        && e.Id == id, trackChanges)
        .SingleOrDefaultAsync();

    public async Task<PagedList<Employee>> GetEmployeesAsync(int companyId, EmployeeParameters employeeParameters, bool trackChanges)
    {
        var employees = await FindByCondition(e => e.CompanyId == companyId, trackChanges)
            .FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
            .Search(employeeParameters.SearchTerm!)
            .ToListAsync();

        return new PagedList<Employee>(employees,
            employees.Count, employeeParameters.PageNumber,
            employeeParameters.PageSize);

    }

    public void DeleteEmployee(Employee employee) => Delete(employee);
}
