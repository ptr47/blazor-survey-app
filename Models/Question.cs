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
        public Survey Survey { get; set;}

        public ICollection<Answer>? Answers { get; set; }

    }
    public class Answer()
    {
        public string Text { get; set; }
    }
}
