using Microsoft.EntityFrameworkCore;
using Cine_API.Entities;

    namespace Cine_API.Data
{
    public class MovieTheaterContext(DbContextOptions<MovieTheaterContext> options) 
        : DbContext(options)
    {
        public DbSet<Director> Directors => Set<Director>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Show> Shows => Set<Show>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new { MovieId = 1, MovieName = "Star Wars ep1", DirectorId = 1, IsNational = false, Length = 120, MovieImg = "https://i.ebayimg.com/images/g/~iwAAOSwlkhdj3yZ/s-l1200.jpg" },
                new { MovieId = 2, MovieName = "Star Wars ep2", DirectorId = 1, IsNational = false, Length = 120, MovieImg = "https://i.pinimg.com/originals/06/34/3c/06343c9d80c8d13be65c412b5cd5e81e.png" },
                new { MovieId = 3, MovieName = "Matrix", DirectorId = 2, IsNational = false, Length = 120, MovieImg = "https://i.pinimg.com/736x/01/fd/98/01fd9847e3bf83bc01f7f59ff2ee50ca.jpg" },
                new { MovieId = 4, MovieName = "Relatos Salvajes", DirectorId = 3, IsNational = true, Length = 120, MovieImg = "https://www.lahiguera.net/cinemania/pelicula/6272/relatos_salvajes-cartel-5709.jpg" }
            );
            modelBuilder.Entity<Director>().HasData(
                new { DirectorId = 1, DirectorName = "George Lucas" },
                new { DirectorId = 2, DirectorName = "Hermanas Wachowski" },
                new { DirectorId = 3, DirectorName = "Damián Szifron" }
            );
        }
    }
}
