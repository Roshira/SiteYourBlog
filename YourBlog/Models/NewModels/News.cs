// Models/NewsModels/News.cs
using System;
using System.ComponentModel.DataAnnotations;
using YourBlog.Models.UserModels;

namespace YourBlog.Models.NewsModels
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [StringLength(500)]
        public string ImageUrl { get; set; }
    }
}