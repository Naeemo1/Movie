
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Server.Helpers;
using Movies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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


        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPerson()
        {
            return await context.Actors.ToListAsync();
        }

        [HttpGet]
        [Route("/api/GetFiles")]
        public IEnumerable<string> GetFiles()
        {
            try
            {
                var path = Path.Combine($"wwwroot/actor");
                var files = System.IO.Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);

                List<string> vs = new List<string>();
                foreach (string item in files)
                {
                    //string fileName = System.IO.Path.GetFileName(item);
                    string fileName = item.Split(new string[] { "wwwroot" }, StringSplitOptions.None)[1];
                    vs.Add(fileName);
                }
                return vs;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person)
        {
            if (person.Picture !=null)
            {
                foreach (var item in person.Picture.Distinct())
                {
                    var personImage = Convert.FromBase64String(item);
                    await fileStorageService.SaveFile(personImage, "jpg", ContainerName);
                }
                
            }

            context.Add(person);
            await context.SaveChangesAsync();
            return person.PersonID;
        }

    }
}
