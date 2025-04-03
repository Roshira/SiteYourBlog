// Models/News.cs
using System.ComponentModel.DataAnnotations;

namespace YourBlog.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(0, 2)]
        public int AccessLevel { get; set; } // 0-публічний, 1-авторизований, 2-підписник

        public string? AuthorId { get; set; }
    }
}