using BackExeBooks1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string UserLogin { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public int Money { get; set; }
    [Required]
    public int role { get; set; }
    public List<PurchaseList> PurchaseList { get; set; } = new();
    public List<Author> Author { get; set; } = new();
    public List<PurchaseListA> PurchaseListA     { get; set; } = new();
}