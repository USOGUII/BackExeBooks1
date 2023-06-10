using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackExeBooks1.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string BookDescription { get; set; }
        [Required]
        public string BookAuthor { get; set; }
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
        public string BookUrl { get; set; }
        [Required]
        public int PublishingHouseId { get; set; }
        [ForeignKey(nameof(PublishingHouseId))]
        public PublishingHouse PublishingHouse { get; set; }

    }
}
