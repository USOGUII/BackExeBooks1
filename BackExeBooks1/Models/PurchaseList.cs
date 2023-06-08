using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackExeBooks1.Models
{
    public class PurchaseList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }
        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public int? BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book? Book { get; set; }
    }
}
