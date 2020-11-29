using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Shared.Entities
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        public List<MoviesGenres> MoviesGenres { get; set; } = new List<MoviesGenres>();

    }
}
