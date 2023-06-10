using BackExeBooks1.Models;

namespace BackExeBooks1.Managers
{
    public class FillPurchaseList
    {
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }
    }
}
