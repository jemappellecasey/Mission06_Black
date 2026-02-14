using Microsoft.EntityFrameworkCore;
using Mission06.Models;

namespace Mission06.Data;

public class MovieCollectionDbContext : DbContext
{
    public MovieCollectionDbContext(DbContextOptions<MovieCollectionDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Action/Adventure" },
            new Category { CategoryId = 2, Name = "Comedy" },
            new Category { CategoryId = 3, Name = "Drama" },
            new Category { CategoryId = 4, Name = "Family" },
            new Category { CategoryId = 5, Name = "Horror/Suspense" },
            new Category { CategoryId = 6, Name = "Miscellaneous" },
            new Category { CategoryId = 7, Name = "Television" }
        );
    }
}
