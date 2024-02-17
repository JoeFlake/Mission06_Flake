using Microsoft.EntityFrameworkCore;

namespace Mission06_Flake.Models
{
    public class MovieAdderContext : DbContext
    {
        public MovieAdderContext(DbContextOptions<MovieAdderContext> options) : base (options) //Constructor
        {

        }

        public DbSet<MovieViewModel> Movies { get; set; }
    }
}
