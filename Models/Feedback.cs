using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Feedback()
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; }
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public List<FeedbackAnswer> Answers { get; set; } = new List<FeedbackAnswer>();
    }
    public class FeedbackAnswer()
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid QuestionId { get; set; }
        public Guid FeedbackId { get; set; }
        public Question Question { get; set; }
        public string? Answer { get; set; }
    }
}