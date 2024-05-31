using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Survey()
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        [Required(ErrorMessage ="Survey Title is required")]
        [StringLength(99)]
        public string Title { get; set; }
        [Required(ErrorMessage ="Survey needs questions")]
        public List<Question> Questions { get; set; } = new();

    }
}
