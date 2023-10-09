namespace COMP2084Project.Models
{
    public class AudioEntry
    {
        public int AudioEntryId { get; set; }
        public int position { get; set; }
        public int AlbumId { get; set; }
        public int AudioListId { get; set; }
        public Album? Albums { get; set; }
        public AudioList? AudioLists { get; set; }
    }
}
