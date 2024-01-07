using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class Company
{
    [Column("CompanyId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Company Name is required field")]
    [MaxLength(50, ErrorMessage = "Maximum length for Name is 50 characters")]
    public string? Name { get; set; }
    public string? Country { get; set; }

    [Required(ErrorMessage = "Company address is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
    public string? Address { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

}
