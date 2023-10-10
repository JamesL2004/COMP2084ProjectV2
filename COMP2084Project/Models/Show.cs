using System.ComponentModel.DataAnnotations;

namespace COMP2084Project.Models
{
    public class Show
    {
        [Required]
        [Display(Name = "Show")]
        public int ShowId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Show Creator")]
        [MaxLength(50)]
        public string ShowCreator { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int ScreenGenreId { get; set; }
        [Required]
        [Range(0, 10)]
        [Display(Name = "Rating")]
        public int rating { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Review")]
        public string review { get; set; }
        public ScreenGenre? ScreenGenre { get; set; }
        public List<ShowEntry>? ShowEntries { get; set; }
    }
}
