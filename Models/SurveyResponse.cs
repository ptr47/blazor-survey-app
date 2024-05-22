using System;
using System.Collections.Generic;

namespace WebApp.Models
{

    public class SurveyResponse
    {
        public int Id { get; set; }
        public Dictionary<int, ISurveyAnswer> Answers { get; set; } = new();
    }

}
