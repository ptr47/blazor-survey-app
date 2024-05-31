using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Answer()
    {
        [Required(ErrorMessage = "Answer is required")]
        public string Text { get; set; }
    }
}
