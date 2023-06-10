using BackExeBooks1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackExeBooks1.Managers
{
    public class CreateAuthorBook
    {
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookDate { get; set; }
        public string BookGenre { get; set; }
        public int BookPrice { get; set; }
        public string BookLenght { get; set; }
        public string imgUrl { get; set; }
        public string BookUrl { get; set; }
        public string authName { get; set; }
        public string authFamiliya { get; set; }
        public string authOtchestvo { get; set; }
        public int AuthorId { get; set; }
    }
}
