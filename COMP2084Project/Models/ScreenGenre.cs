namespace COMP2084Project.Models
{
    public class ScreenGenre
    {
        public int ScreenGenreId { get; set; }
        public string Name { get; set; }

        public List<Movie>? Movies { get; set; }
        public List<Show>? Shows { get; set; }
    }
}
