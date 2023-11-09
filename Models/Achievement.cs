namespace NoTrackingBug.Models;

public class Achievement : AuditableEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Points { get; set; }

    public ICollection<UserAchievement> UserAchievements { get; set; } = new HashSet<UserAchievement>();
    public ICollection<Quiz> Quizzes { get; set; } = new HashSet<Quiz>();

    public string IntegrationId { get; set; }
}
