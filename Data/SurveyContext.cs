using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class SurveyContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public SurveyContext(DbContextOptions<SurveyContext> options) : base(options)
        {
        }
    }
}
