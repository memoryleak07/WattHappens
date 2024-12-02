namespace WattHappens.Application.Common;

public class ConnectionStrings
{
    public required string DefaultConnection { get; set; }
}

public class AppSettings
{
    public required ConnectionStrings ConnectionStrings { get; set; }
}