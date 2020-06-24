using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using MovieSystem.AppService;
using MovieSystem.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieSystem
{
    public class MovieController : ApiController
    {
        private IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;

        }
        /// <summary>
        /// The API returns the list of Movies
        /// </summary>
        /// <returns>List of Movie Model</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("/api/movies")]
        public IHttpActionResult GetMovies()
        {
            try {
                List<Movie> movies = _service.FindAll().ToList();
                if (movies.Count == 0)
                {
                    return NotFound();
                }
                return Ok(movies);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        /// <summary>
        /// The API returns Movie Object for a particular movieId
        /// </summary>
        /// <param name="id">Mapped to MovieId</param>
        /// <returns>Movie Model</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("/api/movies/{id}")]
        public IHttpActionResult Search(int id)
        {
            try
            {
                Movie movie = _service.FindBy(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
