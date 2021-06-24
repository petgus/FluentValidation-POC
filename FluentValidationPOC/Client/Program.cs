using FluentValidation;
using FluentValidationPOC.Shared.Models;
using FluentValidationPOC.Shared.Services;
using FluentValidationPOC.Shared.Validators.ArticleValidators;
using FluentValidationPOC.Shared.Validators.UserValidators;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

            builder.Services.AddTransient<IValidator<Article>, LocalizedAsyncArticleValidator>();
            builder.Services.AddTransient<IValidator<User>, UserValidator>();

            await builder.Build().RunAsync();
        }
    }
}
