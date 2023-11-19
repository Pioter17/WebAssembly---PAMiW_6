using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using blazorapp;
using blazorapp.Shared.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using blazorapp.Shared.Services.MovieService;
using blazorapp.Shared.Services.DirectorService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
    Path = appSettingsSection.MovieEndpoint.GetAllMoviesEndpoint,
};

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Microsoft.Extensions.Http
// builder.Services.AddHttpClient<IMovieService, MovieService>(client => client.BaseAddress = uriBuilder.Uri);
// builder.Services.Configure<AppSettings>(appSettings);
builder.Services.AddSingleton<IOptions<AppSettings>>(new OptionsWrapper<AppSettings>(appSettingsSection));
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<DirectorService>();


await builder.Build().RunAsync();
