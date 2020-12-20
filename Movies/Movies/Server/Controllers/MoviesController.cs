using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Server.Helpers;
using Movies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;
        private string ContainerName = "movies";


        public MoviesController(ApplicationDbContext context, IFileStorageService fileStorage, IMapper mapper)
        {
            this.context = context;
            this.fileStorageService = fileStorage;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie)
        {
            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                var movieImage = Convert.FromBase64String(movie.Poster);
                movie.Poster = await fileStorageService.SaveFile(movieImage, "jpg", ContainerName);
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return movie.MovieID;
        }

    }
}
