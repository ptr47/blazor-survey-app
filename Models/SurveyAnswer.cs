using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public interface ISurveyAnswer;

    public class SingleChoiceResponse : ISurveyAnswer
    {
        public string? SelectedAnswer { get; set; }
    }

    public class MultipleChoiceResponse : ISurveyAnswer
    {
        public List<string> SelectedAnswers { get; set; } = new();
    }

}