using Microsoft.EntityFrameworkCore;
using NoTrackingBug.Data.Interceptors;
using NoTrackingBug.Models;

namespace NoTrackingBug.Data;

public class ApplicationDbContext : DbContext
{
    private readonly AchievementInterceptor _achievementInterceptor;
    private readonly AuditableEntityInterceptor _auditableEntityInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        AchievementInterceptor achievementInterceptor,
        AuditableEntityInterceptor auditableEntityInterceptor) : base(options)
    {
        _achievementInterceptor = achievementInterceptor;
        _auditableEntityInterceptor = auditableEntityInterceptor;
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Quiz> Quizzes { get; set; } = null!;
    public DbSet<Achievement> Achievements { get; set; } = null!;
    public DbSet<UserAchievement> UserAchievements { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_achievementInterceptor);
        optionsBuilder.AddInterceptors(_auditableEntityInterceptor);
    }
}
