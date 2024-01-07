using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(SeedEmployees());
    }

    private static List<Employee> SeedEmployees()
    {
        return new()
        {
            new Employee
            {
                Id = 1,
                Name = "Sam Raiden",
                Age = 26,
                Position = "Software developer",
                CompanyId = 1
            },
            new Employee
            {
                Id = 2,
                Name = "Jana McLeaf",
                Age = 30,
                Position = "Software developer",
                CompanyId = 1
            },
             new Employee
             {
                 Id = 3,
                 Name = "Kane Miller",
                 Age = 35,
                 Position = "Administrator",
                 CompanyId = 2
             }
        };
    }
}
