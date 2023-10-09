namespace COMP2084Project.Models
{
    public class AudioList
    {
        public int AudioListId { get; set; }
        public string AudioListName { get; set;}
        public string AudioListDescription { get; set;}
        public List<AudioEntry>? AudioEntries { get; set; }
    }
}
