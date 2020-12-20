using Movies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Client.Repository
{
    public interface IGenreRepository
    {
        Task CreateGenre(Genre genre);
    }
}
