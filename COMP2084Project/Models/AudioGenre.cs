namespace COMP2084Project.Models
{
    public class AudioGenre
    {
        public int AudioGenreId { get; set; }
        public string Name { get; set; }

        public List<Album>? Albums { get; set; }
    }
}
