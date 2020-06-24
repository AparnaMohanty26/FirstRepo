using MovieSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSystem.AppService
{
   public interface IMovieService
    {
        IEnumerable<Movie> FindAll();
        Movie FindBy(int MovieId);
    }
}
