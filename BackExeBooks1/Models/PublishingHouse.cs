using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackExeBooks1.Models
{
    public class PublishingHouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublishingHouseId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double procent { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
