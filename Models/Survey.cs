using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Survey()
    {
        public int Id { get; set; }
        [Required]
        [StringLength(99)]
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}
