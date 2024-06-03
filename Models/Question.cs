using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public enum QuestionType
    {
        SingleChoice,
        MultipleChoice,
        OpenEndedText
    }
    public class Question()
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Question title is required.")]
        [StringLength(99)]
        public string Title { get; set; }
        [Required]
        public QuestionType Type { get; set; }
        public bool IsRequired { get; set; }
        public int Position { get; set; }
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set;}

        public List<Answer>? Answers { get; set; }

    }
    public class Answer()
    {
        [Key]
        public int Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; } = false;
    }
}
