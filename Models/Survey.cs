using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Survey(string title)
    {
        public int Id { get; set; }
        [Required]
        [StringLength(99)]
        public string Title { get; set; } = title;
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<SurveyResponse>? Responses { get; set; }

    }
}
