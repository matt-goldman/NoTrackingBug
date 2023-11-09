namespace NoTrackingBug.Models;

public class Quiz : AuditableEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Achievement Achievement { get; set; }
    public int AchievementId { get; set; }
}
