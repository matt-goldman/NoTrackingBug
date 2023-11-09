namespace NoTrackingBug.Models;

public class Achievement
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Points { get; set; }

    public ICollection<UserAchievement> UserAchievements { get; set; } = new HashSet<UserAchievement>();
    public ICollection<Quiz> Quizzes { get; set; } = new HashSet<Quiz>();

    public DateTime CreatedAt { get; set; }
}
