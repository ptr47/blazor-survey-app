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
        Task<bool> UpdateSurveyAsync(Survey updatedSurvey);
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
            return await _context.Surveys
            .Include(s => s.Questions.OrderBy(q => q.Position))
                .ThenInclude(q => q.Answers)
            .FirstOrDefaultAsync(s => s.Id == surveyId);

        }
        public async Task<bool> UpdateSurveyAsync(Survey updatedSurvey)
        {
            var survey = await _context.Surveys
                .Include(s => s.Questions)
                    .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(s => s.Id == updatedSurvey.Id);

            if (survey == null)
            {
                return false; // Survey not found
            }

            // Update survey properties
            survey.Title = updatedSurvey.Title;

            // Update questions and answers
            foreach (var updatedQuestion in updatedSurvey.Questions)
            {
                var question = survey.Questions.FirstOrDefault(q => q.Id == updatedQuestion.Id);

                if (question != null)
                {
                    // Update existing question
                    question.Title = updatedQuestion.Title;
                    question.IsRequired = updatedQuestion.IsRequired;
                    question.Type = updatedQuestion.Type;

                    // Add new answers
                    question.Answers.Clear();
                    if (question.Type != QuestionType.OpenEndedText)
                    {
                        foreach (var updatedAnswer in updatedQuestion.Answers)
                        {
                            question.Answers.Add(updatedAnswer);
                        }
                    }
                }
                else
                {
                    // Add new question
                    survey.Questions.Add(updatedQuestion);
                }
            }

            // Remove deleted questions
            survey.Questions.RemoveAll(q => !updatedSurvey.Questions.Any(uq => uq.Id == q.Id));

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency issues
                return false;
            }
        }

        public async Task SubmitFeedbackAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }
    }

}
