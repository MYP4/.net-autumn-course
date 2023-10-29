namespace OnlineCinema.Common;

using System.Collections.Generic;

public class HealthCheck
{
    public IEnumerable<HealthCheckItem> HealthChecks { get; set; }
    public string OverallStatus { get; set; }
    public string TotalDuration { get; set; }
}

public class HealthCheckItem
{
    public string Status { get; set; }
    public string Component { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
}
