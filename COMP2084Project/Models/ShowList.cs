using System.ComponentModel.DataAnnotations;

namespace COMP2084Project.Models
{
    public class ShowList
    {
        public int ShowListId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Title")]
        public string ShowListName { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Description")]
        public string ShowListDescription { get; set; }
        public List<ShowEntry>? ShowEntries { get; set; }
    }
}
