using Microsoft.EntityFrameworkCore;
using Mission06.Data;
using Mission06.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieCollectionDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieCollectionConnection")));

var app = builder.Build();

// Ensure database is created and seeded (Model First)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MovieCollectionDbContext>();
    db.Database.EnsureCreated();
    if (!db.Movies.Any())
    {
        db.Movies.AddRange(
            new Movie { CategoryId = 2, Title = "The Shawshank Redemption", Year = 1994, Director = "Frank Darabont", Rating = "R", Edited = false },
            new Movie { CategoryId = 1, Title = "The Dark Knight", Year = 2008, Director = "Christopher Nolan", Rating = "PG-13", Edited = false },
            new Movie { CategoryId = 2, Title = "Back to the Future", Year = 1985, Director = "Robert Zemeckis", Rating = "PG", Edited = false }
        );
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
