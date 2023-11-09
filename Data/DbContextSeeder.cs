using Microsoft.EntityFrameworkCore;
using NoTrackingBug.Models;

namespace NoTrackingBug.Data;

public class DbContextSeeder
{
    private readonly ApplicationDbContext _dbContext;

    public DbContextSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Seed()
    {
        Console.WriteLine("Seeding database...");

        await _dbContext.Database.MigrateAsync();

        var quiz = new Quiz
        {
            Name = "Quiz 1",
            Achievement = new Achievement
            {
                Name = "Achievement 1",
                Points = 10
            }
        };

        var user = new User
        {
            Name = "User 1"
        };

        _dbContext.Quizzes.Add(quiz);
        _dbContext.Users.Add(user);

        await _dbContext.SaveChangesAsync();

        Console.WriteLine("Seeding database done!");
    }
}
