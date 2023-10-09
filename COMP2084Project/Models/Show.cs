using System.ComponentModel.DataAnnotations;

namespace COMP2084Project.Models
{
    public class Show
    {
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
        public int rating { get; set; }
        [Required]
        [MaxLength(500)]
        public string review { get; set; }
        public ScreenGenre? ScreenGenre { get; set; }
        public List<ShowEntry>? ShowEntries { get; set; }
    }
}
