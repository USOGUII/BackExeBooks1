namespace BackExeBooks1.Managers
{
    public class CreateBookRequest
    {
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookAuthor { get; set; }
        public string BookDate { get; set; }
        public string BookGenre { get; set; }
        public int BookPrice { get; set; }
        public string BookLenght { get; set; }
        public string imgUrl { get; set; }
        public int PublishingHouseId { get; set; }
        public string BookUrl { get; set; }
    }
}
