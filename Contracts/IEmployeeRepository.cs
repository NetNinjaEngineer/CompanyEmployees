﻿using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;
public interface IEmployeeRepository
{
    Task<PagedList<Employee>> GetEmployeesAsync(int companyId,
        EmployeeParameters employeeParameters, bool trackChanges);
    Task<Employee> GetEmployeeAsync(int companyId, int id, bool trackChanges);
    void CreateEmployeeForCompany(int companyId, Employee employee);
    void DeleteEmployee(Employee employee);
}
