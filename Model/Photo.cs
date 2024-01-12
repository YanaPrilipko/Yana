namespace HotelAngular.Model
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Changed { get; set; }
        public long Size { get; set; }
        public string FilePath { get; set; }
        public House? House { get; set; } = new House();
        public int? HauseId { get; set; }

    }
}
