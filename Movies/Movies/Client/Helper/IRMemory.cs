using Movies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Client.Helper
{
    public class IRMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie(){ReleaseDate = new DateTime(2019,5,5), Title = "Spider-Man" },
                new Movie(){ReleaseDate = new DateTime(2017,5,5), Title = "Iron-Man" }
            };
        }
    }
}
