using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackExeBooks1.Models
{
    public class PurchaseListA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }
        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public int? AuthorBookId { get; set; }
        [ForeignKey(nameof(AuthorBookId))]
        public AuthorBook? AuthorBook { get; set; } 
    }
}
