﻿using System.ComponentModel.DataAnnotations;

namespace COMP2084Project.Models
{
    public class MovieEntry
    {
        public int MovieEntryId { get; set; }
        [Required]
        [Display(Name = "Position")]
        public int position { get; set; }
        public int MovieId { get; set; }
        public int MovieListId { get; set; }
        public Movie? Movie { get; set; }
        public MovieList? MovieLists { get; set; }
    }
}
