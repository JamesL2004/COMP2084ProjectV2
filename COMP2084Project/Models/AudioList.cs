using System.ComponentModel.DataAnnotations;

namespace COMP2084Project.Models
{
    public class AudioList
    {
        public int AudioListId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Title")]
        public string AudioListName { get; set;}
        [Required]
        [MaxLength(255)]
        [Display(Name = "Description")]
        public string AudioListDescription { get; set;}
        public List<AudioEntry>? AudioEntries { get; set; }
    }
}
