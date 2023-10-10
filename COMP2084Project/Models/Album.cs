using System.ComponentModel.DataAnnotations;

namespace COMP2084Project.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int AudioGenreId { get; set; }
        [Required]
        [Range(0, 10)]
        [Display(Name = "Rating")]
        public int rating { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Review")]
        public string review { get; set; }

        public AudioGenre? AudioGenre { get; set; }
        public List<AudioEntry>? AudioEntries { get; set; }
    }
}
