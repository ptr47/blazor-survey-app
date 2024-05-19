using System;
using System.Collections.Generic;

namespace BlazorSurvey
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}