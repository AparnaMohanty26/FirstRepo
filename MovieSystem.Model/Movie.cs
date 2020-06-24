using System;
using System.ComponentModel.DataAnnotations;

namespace MovieSystem.Model
{
    public class Movie
    {
        [Key]
        public int movieId { get; set; }

        public string movieName { get; set; }

        public DateTime movieTime { get; set; }

        public string movieInfo { get; set; }
    }
}
