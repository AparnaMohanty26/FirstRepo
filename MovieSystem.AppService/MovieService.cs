using MovieSystem.Model;
using MovieSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieSystem.AppService
{
   public class MovieService :IMovieService
    {
        private MovieSystemContext context;
        public MovieService(MovieSystemContext ctx)
        {
            context = ctx;

        }
        public IEnumerable<Movie> FindAll()
        {
            var result = context.Movies.OrderBy(x => x.movieName);
            return result;

        }

        public Movie FindBy(int MovieId)
        {
            return context.Movies.FirstOrDefault(x => x.movieId == MovieId);
        }
    }
}
