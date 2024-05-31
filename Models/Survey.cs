using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Survey()
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage ="Survey Title is required")]
        [StringLength(99)]
        public string Title { get; set; }
        [Required(ErrorMessage ="Survey needs questions")]
        public List<Question> Questions { get; set; } = new();

    }
}
