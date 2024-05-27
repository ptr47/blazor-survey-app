using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class SurveyCreateService
    {
        private readonly SurveyContext _context;

        public SurveyCreateService(SurveyContext context)
        {
            _context = context;
        }

        public async Task AddSurveyAsync(Survey survey)
        {
            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();
        }
    }
}
