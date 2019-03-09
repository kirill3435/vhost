namespace AVideoHost.Models
{
    public class TitleItem
    {
        public TitleItem()
        { }

        public int Id { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
        public int TitleId { get; set; }
        public Title Title { get; set; }
    }
}
