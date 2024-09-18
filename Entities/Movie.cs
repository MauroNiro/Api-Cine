using Cine_API.Data;

namespace Cine_API.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public required string MovieName { get; set; }   
        public int DirectorId { get; set; } 
        public  Director? Director { get; set; }
        public bool IsNational { get; set; }
        public int Length { get; set; }
        public required string MovieImg { get; set; }

        public static Movie? FindMovie(MovieTheaterContext dbContext, int movieId)
        {
            var movie = dbContext.Movies.Where(movie => movie.MovieId == movieId).FirstOrDefault();
            if (movie == null)
            {
                return null;
            }
            return movie;
        }
    }
}
