using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class FeedbackAnswer()
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; }
        public Guid QuestionId { get; set; }        
        public Question Question { get; set; }
        public string? Answer { get; set; }
    }
}