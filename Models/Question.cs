using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public enum QuestionType
    {
        SingleChoice,
        MultipleChoice,
        OpenEndedText
    }
    public class Question(string title)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;
        public QuestionType Type { get; set; }

        public List<string>? Answers { get; set; }

    }
}
