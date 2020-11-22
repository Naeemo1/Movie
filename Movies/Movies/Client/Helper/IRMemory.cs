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
                new Movie(){ReleaseDate = new DateTime(2019,5,5), Title = "Spider-Man", Poster="https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UY1200_CR90,0,630,1200_AL_.jpg" },
                new Movie(){ReleaseDate = new DateTime(2017,5,5), Title = "Iron-Man", Poster = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_.jpg" }
            };
        }
    }
}
