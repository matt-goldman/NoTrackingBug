//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using NoTrackingBug.Models;

//namespace NoTrackingBug.Data.Configurations;

//public class UserAchievementConfiguration : IEntityTypeConfiguration<UserAchievement>
//{
//    public void Configure(EntityTypeBuilder<UserAchievement> builder)
//    {
//        builder
//            .HasOne(ua => ua.User)
//            .WithMany(u => u.Achievements);

//        builder
//            .HasOne(ua => ua.Achievement)
//            .WithMany(u => u.UserAchievements);

//        builder
//            .HasIndex(ua => new { ua.UserId, ua.AchievementId });
//    }
//}
