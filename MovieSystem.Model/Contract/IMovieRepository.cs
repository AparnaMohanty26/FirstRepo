using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSystem.Model.Contract
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> FindAll();
        Movie FindBy(int MovieId);
    }
}
