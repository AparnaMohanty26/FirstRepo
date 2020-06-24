using MovieSystem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace MovieSystem.Repository
{
    public class MovieSystemContext:DbContext
    {
        public MovieSystemContext(DbContextOptions<MovieSystemContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
    }
}

