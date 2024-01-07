namespace Shared.DataTrasferObjects;
public record CompanyDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? FullAddress { get; set; }
}
