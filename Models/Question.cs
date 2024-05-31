using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Question title is required.")]
        public string Title { get; set; }
        public QuestionType Type { get; set; }

        public IList<Answer>? Answers { get; set; }
        public Survey Survey { get; set;}

    }
    [Owned]
    public class Answer()
    {
        public string Text { get; set; }
    }
}
