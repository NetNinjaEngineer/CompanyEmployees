namespace Shared.RequestFeatures;
public sealed class EmployeeParameters : RequestParameters
{
    EmployeeParameters() => OrderBy = "name";

    public uint MinAge { get; set; }

    public uint MaxAge { get; set; } = int.MaxValue;

    public bool ValidAgeRange => MaxAge > MinAge;

    public string? SearchTerm { get; set; }
}
