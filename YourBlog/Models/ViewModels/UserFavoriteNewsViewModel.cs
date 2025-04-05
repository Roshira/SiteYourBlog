using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using YourBlog.Models.ViewModel;
using YourBlog.Models.ViewModels;

public class UserFavoriteNewsViewModel
{
    [Key]
    [Column(Order = 1)]
    public string UserName { get; set; }  // Змінено з `int` на `string`

    [ForeignKey("UserId")]
    public UserViewModel User { get; set; }

    [Key]
    [Column(Order = 2)]
    public int NewsId { get; set; }

    [ForeignKey("NewsId")]
    public NewsViewModel News { get; set; }
}