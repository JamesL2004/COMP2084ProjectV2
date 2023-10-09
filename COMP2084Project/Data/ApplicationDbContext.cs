using COMP2084Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COMP2084Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ScreenGenre> ScreenGenres { get; set; }
        public DbSet<AudioGenre> AudioGenres { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<COMP2084Project.Models.AudioEntry> AudioEntry { get; set; } = default!;
        public DbSet<COMP2084Project.Models.AudioList> AudioList { get; set; } = default!;
        public DbSet<COMP2084Project.Models.AudioEntry> MovieEntry { get; set; } = default!;
        public DbSet<COMP2084Project.Models.AudioEntry> MovieList { get; set; } = default!;
        public DbSet<COMP2084Project.Models.AudioEntry> ShowEntry { get; set; } = default!;
        public DbSet<COMP2084Project.Models.AudioEntry> ShowList { get; set; } = default!;
        public DbSet<COMP2084Project.Models.MovieEntry> MovieEntry_1 { get; set; } = default!;
        public DbSet<COMP2084Project.Models.MovieList> MovieList_1 { get; set; } = default!;
        public DbSet<COMP2084Project.Models.ShowEntry> ShowEntry_1 { get; set; } = default!;
        public DbSet<COMP2084Project.Models.ShowList> ShowList_1 { get; set; } = default!;
    }
}