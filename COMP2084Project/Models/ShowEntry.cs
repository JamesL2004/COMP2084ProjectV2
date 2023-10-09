namespace COMP2084Project.Models
{
    public class ShowEntry
    {
        public int ShowEntryId { get; set; }
        public int position { get; set; }
        public int ShowId { get; set; }
        public int ShowListId { get; set; }
        public Show? Shows { get; set; }
        public ShowList? ShowLists { get; set; }
    }
}
