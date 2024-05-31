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
        public int Id { get; set; }
        [Required(ErrorMessage = "Question title is required.")]
        public string Title { get; set; }
        public QuestionType Type { get; set; }

        public IList<Answer>? Answers { get; set; }

    }
}
