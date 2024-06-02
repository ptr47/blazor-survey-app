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
        public ICollection<FeedbackAnswer> Answers { get; set; } = new List<FeedbackAnswer>();
    }
    public class FeedbackAnswer()
    {
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public string Answer { get; set; }
    }
}