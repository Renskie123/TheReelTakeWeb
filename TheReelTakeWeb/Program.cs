using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using TheReelTake.DataAccess.Repository.IMDBRepository.IIMDBRepository;
using TheReelTake.DataAccess.Repository.TMDBRepository;
using TheReelTake.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure TMDB API settings
builder.Services.Configure<TmdbApiSettings>(builder.Configuration.GetSection("TmdbApi"));

// Register HTTP Client
builder.Services.AddHttpClient<ITmdbService, TmdbService>((serviceProvider, client) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<TmdbApiSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

// Register services
builder.Services.AddScoped<ITmdbService, TmdbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
