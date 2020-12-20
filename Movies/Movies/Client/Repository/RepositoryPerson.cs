using Movies.Client.Helper;
using Movies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Client.Repository
{
    public class RepositoryPerson : IRepositoryPerson
    {
        private readonly IHttpService httpService;
        private string url = "api/actor";

        public RepositoryPerson(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task CreatePerson(Person person)
        {
            var response = await httpService.Post(url, person);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

        }
    }
}
