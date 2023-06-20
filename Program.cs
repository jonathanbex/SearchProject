using GoogleApi.Extensions;
using SearchProject.Domain.SearchProviders;
using SearchProject.Domain.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//DI google
builder.Services.AddGoogleApiClients();
//unsure what google is so scoped it is
builder.Services.AddScoped<GoogleSearchProvider>();
builder.Services.AddScoped<BingSearchProvider>();
builder.Services.AddScoped<ResultProvider>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
