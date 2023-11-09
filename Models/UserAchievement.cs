namespace NoTrackingBug.Models;

public class UserAchievement : AuditableEntity
{
    public int Id { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }

    public Achievement Achievement { get; set; }
    public int AchievementId { get; set; }
}
