using System;
using System.Collections.Generic;

namespace WebApp.Models
{

    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public string AnswerText { get; set; }
        public Answer(int id, int questionId, string answerText)
        {
            Id = id;
            QuestionId = questionId;
            AnswerText = answerText;
        }

    }

}
