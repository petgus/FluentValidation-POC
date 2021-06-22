using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidationPOC.Shared.Services;

namespace FluentValidationPOC.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices();

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddSingleton<ISkumArticleService, SkumArticleService>();


            await builder.Build().RunAsync();
        }
    }
}
