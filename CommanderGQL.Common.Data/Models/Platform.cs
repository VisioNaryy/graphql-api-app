namespace CommanderGQL.Common.Models;

public class Platform
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public string? LicenseKey { get; set; }
    
    public ICollection<Command>? Commands { get; set; }
}