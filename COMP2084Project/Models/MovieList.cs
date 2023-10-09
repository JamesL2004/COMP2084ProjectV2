namespace COMP2084Project.Models
{
    public class MovieList
    {
        public int MovieListId { get; set; }
        public string MovieListName { get; set; }
        public string MovieListDescription { get; set; }
        public List<ShowEntry>? ShowEntries { get; set; }
    }
}
