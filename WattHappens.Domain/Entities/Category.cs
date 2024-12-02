using WattHappens.Application.Constants;

namespace WattHappens.Domain.Entities;

public class Category
{
    public EnCategory  Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}