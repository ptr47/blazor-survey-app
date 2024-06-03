using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class SurveyContext(DbContextOptions<SurveyContext> options) : DbContext(options)
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<FeedbackAnswer> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Survey>()
                .HasIndex(s => s.UserId);

        }
    }
}
