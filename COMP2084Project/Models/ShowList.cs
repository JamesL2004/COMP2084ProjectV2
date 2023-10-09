namespace COMP2084Project.Models
{
    public class ShowList
    {
        public int ShowListId { get; set; }
        public string ShowListName { get; set; }
        public string ShowListDescription { get; set; }
        public List<ShowEntry>? ShowEntries { get; set; }
    }
}
