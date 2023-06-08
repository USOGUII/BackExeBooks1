using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackExeBooks1.Models
{
    public class AuthorBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorBookId { get; set; }
        public string BookName { get; set; }
        [Required]
        public string BookDescription { get; set; }
        [Required]
        public string BookDate { get; set; }
        [Required]
        public string BookGenre { get; set; }
        [Required]
        public int BookPrice { get; set; }
        [Required]
        public string BookLenght { get; set; }
        [Required]
        public string imgUrl { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }
        public List<PurchaseListA> PurchaseListA { get; set; } = new();
    }
}
