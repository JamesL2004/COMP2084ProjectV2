using System.ComponentModel.DataAnnotations;

namespace COMP2084Project.Models
{
    public class ShowEntry
    {
        public int ShowEntryId { get; set; }
        [Required]
        [Display(Name = "Position")]
        public int position { get; set; }
        public int ShowId { get; set; }
        [Required]
        [Display(Name = "List Name")]
        public int ShowListId { get; set; }
        public Show? Shows { get; set; }
        public ShowList? ShowLists { get; set; }
    }
}
