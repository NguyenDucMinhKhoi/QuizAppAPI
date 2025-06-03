using Microsoft.EntityFrameworkCore;
using QuizAppApi.Models;

namespace QuizAppApi.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerChoice> AnswerChoices { get; set; }
        public DbSet<QuizSession> QuizSessions { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAnswer>()
                .HasIndex(u => new { u.QuizSessionId, u.QuestionId })
                .IsUnique();

            modelBuilder.Entity<Question>()
                .HasMany(q => q.AnswerChoices)
                .WithOne(ac => ac.Question)
                .HasForeignKey(ac => ac.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.UserAnswers)
                .WithOne(ua => ua.Question)
                .HasForeignKey(ua => ua.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AnswerChoice>()
                .HasMany(ac => ac.UserAnswers)
                .WithOne(ua => ua.SelectedChoice)
                .HasForeignKey(ua => ua.SelectedChoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuizSession>()
                .HasMany(qs => qs.UserAnswers)
                .WithOne(ua => ua.QuizSession)
                .HasForeignKey(ua => ua.QuizSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.QuizSessions)
                .WithOne(qs => qs.User)
                .HasForeignKey(qs => qs.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
