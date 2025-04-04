using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourBlog.Models.News
{
    public class News
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заголовок обов'язковий")]
        [StringLength(200, ErrorMessage = "Заголовок не може перевищувати 200 символів")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Контент обов'язковий")]
        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; } 

        [Required]
        [Range(0, 2, ErrorMessage = "Рівень доступу має бути між 0 та 2")]
        public AccessLevel AccessLevel { get; set; } = AccessLevel.Public;

        [StringLength(500)]
        [Url(ErrorMessage = "Посилання на зображення має бути валідним URL")]
        public string ImageUrl { get; set; }

        [StringLength(100)]
        public string MetaKeywords { get; set; }

        [StringLength(200)]
        public string MetaDescription { get; set; }
    }

    public enum AccessLevel
    {
        Public = 0,      // для всіх
        Authorized = 1,  // тільки для авторизованих
        Subscriber = 2   // тільки для підписників
    }
}