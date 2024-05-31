using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class SurveyContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }

        public SurveyContext(DbContextOptions<SurveyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Answer>()
                .HasNoKey();
        }
    }
}
