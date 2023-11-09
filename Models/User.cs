namespace NoTrackingBug.Models;

public class User : AuditableEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<UserAchievement> Achievements { get; set; } = new HashSet<UserAchievement>();
}
