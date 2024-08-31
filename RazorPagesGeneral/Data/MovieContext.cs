using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MovieLibrary;
using RazorPagesGeneral.Model;

namespace RazorPagesGeneral.Data
{
    public class MovieContext(DbContextOptions<MovieContext> options) : IdentityDbContext(options)
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<HallCinema>? HallCinemas { get; set; }
        public DbSet<Shedule>? Shedules { get; set; }
    }
}
