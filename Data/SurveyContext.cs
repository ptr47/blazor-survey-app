using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class SurveyContext(DbContextOptions<SurveyContext> options) : DbContext(options)
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Survey>()
                .HasIndex(s => s.UserId);

            modelBuilder.Entity<Question>()
            .OwnsMany(q => q.Answers, a =>
            {
                a.WithOwner().HasForeignKey("QuestionId");
                a.Property<int>("Id");
                a.HasKey("Id");
            });
            
            modelBuilder.Entity<Feedback>()
                .HasIndex(f => f.UserId);
            modelBuilder.Entity<Feedback>()
            .OwnsMany(q => q.Answers, a =>
            {
                a.WithOwner().HasForeignKey("QuestionId");
                a.Property<int>("Id");
                a.HasKey("Id");
            });
        }
    }
}
