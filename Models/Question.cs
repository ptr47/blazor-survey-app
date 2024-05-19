using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public enum QuestionType
    {
        SingleChoice,
        MultipleChoice,
        OpenEndedText,
        NumericRange,
        YesNo
    }
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionType Type { get; set; }

        public decimal? NumericRangeMin { get; set; }
        public decimal? NumericRangeMax { get; set; }

    }
}
