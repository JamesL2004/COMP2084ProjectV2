using System.ComponentModel.DataAnnotations;

namespace COMP2084Project.Models
{
    public class MovieList
    {
        public int MovieListId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Title")]
        public string MovieListName { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Description")]
        public string MovieListDescription { get; set; }
        public List<ShowEntry>? ShowEntries { get; set; }
    }
}
