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
        Task<Survey?> GetSurveyByIdAsync(Guid surveyId);
        Task SubmitFeedbackAsync(Feedback feedback);
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
        public async Task<Survey> CreateSurveyFromExistingAsync(Guid existingSurveyId)
        {
            var existingSurvey = await GetSurveyByIdAsync(existingSurveyId) ?? throw new InvalidOperationException("Survey not found.");

            var newSurvey = new Survey
            {
                Id = Guid.NewGuid(),
                UserId = existingSurvey.UserId,
                Title = existingSurvey.Title,
            };
            newSurvey.Questions = existingSurvey.Questions.Select(q => new Question
            {
                Id = Guid.NewGuid(),
                SurveyId = newSurvey.Id,
                Title = q.Title,
                IsRequired = q.IsRequired,
                Type = q.Type,
                Answers = q.Answers
            }).ToList();

            _context.Surveys.Add(newSurvey);
            await _context.SaveChangesAsync();

            return newSurvey;
        }
        public async Task SubmitFeedbackAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }
    }

}
