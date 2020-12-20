
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
    public class ActorController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;
        private string ContainerName = "actor";


        public ActorController(ApplicationDbContext context, IFileStorageService fileStorage, IMapper mapper)
        {
            this.context = context;
            this.fileStorageService = fileStorage;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person)
        {
            if (!string.IsNullOrWhiteSpace(person.Picture))
            {
                var personImage = Convert.FromBase64String(person.Picture);
                person.Picture = await fileStorageService.SaveFile(personImage, "jpg", ContainerName);
            }

            context.Add(person);
            await context.SaveChangesAsync();
            return person.PersonID;
        }

    }
}
