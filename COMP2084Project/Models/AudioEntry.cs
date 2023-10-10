using System.ComponentModel.DataAnnotations;

namespace COMP2084Project.Models
{
    public class AudioEntry
    {
        public int AudioEntryId { get; set; }
        [Required]
        [Display(Name = "Position")]
        public int position { get; set; }
        public int AlbumId { get; set; }
        public int AudioListId { get; set; }
        public Album? Albums { get; set; }
        public AudioList? AudioLists { get; set; }
    }
}
