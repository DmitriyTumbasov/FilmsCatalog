namespace FilmsCatalog.Data.Models
{
    public class Film
    {
        public long Id { get; set; }
        public User Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string FilmDirector { get; set; }
        public byte[] ImageFile { get; set; }
    }
}
