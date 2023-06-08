using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackExeBooks1.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Familiya { get; set; }
        [Required]
        public string Otchestvo { get; set; }
        [Required]
        public double procent { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
    }
}
