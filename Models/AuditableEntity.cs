namespace NoTrackingBug.Models;

public class AuditableEntity
{
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}
