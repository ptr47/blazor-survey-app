using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services
{
    public interface ISurveyService
    {
        Task AddSurveyAsync(Survey survey);
        Task DeleteSurveyAsync(Survey survey);
    }

    public class SurveyService(SurveyContext context) : ISurveyService
    {
        private readonly SurveyContext _context = context;

        public async Task AddSurveyAsync(Survey survey)
        {
            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSurveyAsync(Survey survey)
        {
            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
        }
        public async Task<Survey?> GetSurveyByIdAsync(Guid surveyId)
        {
            return await _context.Surveys.FirstOrDefaultAsync(s => s.Id == surveyId);
        }
    }
}
