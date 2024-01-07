using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTrasferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;
public interface IEmployeeService
{
    Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesAsync(int companyId,
    EmployeeParameters employeeParameters, bool trackChanges);
    Task<EmployeeDto> GetEmployeeAsync(int companyId, int id, bool trackChanges);
    Task<EmployeeDto> CreateEmployeeForCompanyAsync(int companyId,
        EmployeeForCreationDto employeeForCreation, bool trackChanges);
    Task DeleteEmployeeForCompanyAsync(int companyId, int id, bool trackChanges);
    Task UpdateEmployeeForCompanyAsync(int companyId, int id,
        EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);
    Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(
        int companyId, int id, bool compTrackChanges, bool empTrackChanges);
    Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
}
