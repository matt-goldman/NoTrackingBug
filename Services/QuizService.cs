using Microsoft.EntityFrameworkCore;
using NoTrackingBug.Data;
using NoTrackingBug.Models;

namespace NoTrackingBug.Services;

public class QuizService
{
    private readonly ApplicationDbContext _dbContext;

    public QuizService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ProcessQuiz(int quizId, int userId, bool passed, bool track)
    {
        var query = _dbContext.Quizzes
            .Include(q => q.Achievement)
            .Where(q => q.Id == quizId);

        if (!track)
        {
            Console.WriteLine("Disabling tracking...");
            query = query.AsNoTracking();
        }

        var quiz = await query.FirstOrDefaultAsync();

        if (passed)
        {
            AddQuizAchievement(quiz.AchievementId, userId);

            await _dbContext.SaveChangesAsync();
        }

        Console.WriteLine("Quiz processed!");
    }

    private void AddQuizAchievement(int achievementId, int userId)
    {
        var ua = new UserAchievement
        {
            AchievementId = achievementId,
            UserId = userId
        };

        _dbContext.UserAchievements.Add(ua);
    }
}
