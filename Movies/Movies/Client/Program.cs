using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Movies.Client.Helper;
using Movies.Client.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace Movies.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //Important
            ConfiguredServices(builder.Services);
            await builder.Build().RunAsync();
        }

        private static void ConfiguredServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddTransient<IRepository, IRMemory>();

            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IRepositoryPerson, RepositoryPerson>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddFileReaderService(op => op.InitializeOnFirstCall = true);
            services.AddBlazoredModal();
        }

    }
}
