using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class SurveyContext(DbContextOptions<SurveyContext> options) : DbContext(options)
    {
        public DbSet<Survey> Surveys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
            .OwnsMany(q => q.Answers);
        }
    }
}
