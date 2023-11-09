// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NoTrackingBug.Data;
using NoTrackingBug.Data.Interceptors;
using NoTrackingBug.Services;

Console.WriteLine("Hello, World!");

int userId = 0;
int quizId = 0;
bool passed = false;
bool useTracking = false;
bool seedDatabase = false;

if (args.Contains("--interactive"))
{
    Console.WriteLine("Seed database?");
    seedDatabase = bool.Parse(Console.ReadLine()!);

    if (!seedDatabase)
    {
        Console.WriteLine("Enter user id:");
        userId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter quiz id:");
        quizId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter passed:");
        passed = bool.Parse(Console.ReadLine()!);

        Console.WriteLine("Use tracking?");
        useTracking = bool.Parse(Console.ReadLine()!);
    }
}

var host = Host.CreateDefaultBuilder(args);


host.ConfigureServices(services =>
{
    services.AddScoped<AchievementInterceptor>();

    services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NoTrackingBug;Trusted_Connection=True;MultipleActiveResultSets=true"));

    services.AddScoped<DbContextSeeder>();

    services.AddScoped<QuizService>();
});

var app = host.Build();

if (!args.Contains("--interactive"))
{
    return;
}


if (seedDatabase)
{
    var seeder = app.Services.GetRequiredService<DbContextSeeder>();

    await seeder.Seed();
}
else
{
    var quizService = app.Services.GetRequiredService<QuizService>();

    await quizService.ProcessQuiz(quizId, userId, passed, useTracking);
}
