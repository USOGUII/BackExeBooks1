using BackExeBooks1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackExeBooks1.Managers
{
    public class FillPurchaseListA
    {
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? AuthorBookId { get; set; }
        public AuthorBook? AuthorBook { get; set; }
    }
}
