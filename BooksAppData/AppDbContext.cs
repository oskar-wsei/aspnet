using BooksAppData.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksAppData;

public class AppDbContext : DbContext
{
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }

    private readonly string _storagePath;

    public AppDbContext()
    {
        var appDataFolder = Environment.SpecialFolder.LocalApplicationData;
        var appDataPath = Environment.GetFolderPath(appDataFolder);
        _storagePath = Path.Join(appDataPath, "book_app.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={_storagePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookEntity>()
            .HasOne(book => book.Author)
            .WithMany(author => author.Books)
            .HasForeignKey(book => book.AuthorId);

        modelBuilder.Entity<AuthorEntity>().HasData(
            new AuthorEntity
            {
                Id = 1,
                FirstName = "Andrew",
                LastName = "Lock"
            },
            new AuthorEntity
            {
                Id = 2,
                FirstName = "Christian",
                LastName = "Gammelgaard"
            }, new AuthorEntity
            {
                Id = 3,
                FirstName = "Marinko",
                LastName = "Spasojevic"
            }
        );

        modelBuilder.Entity<BookEntity>().HasData(
            new BookEntity
            {
                Id = 1,
                Title = "ASP.NET Core in Action",
                AuthorId = 1,
                Pages = 370,
                PublishYear = 2017,
                CreatedAt = DateTime.Parse("2021-02-25")
            },
            new BookEntity
            {
                Id = 2,
                Title = "Microservices in .NET",
                AuthorId = 2,
                Pages = 300,
                PublishYear = 2020,
                CreatedAt = DateTime.Parse("2019-11-01")
            },
            new BookEntity
            {
                Id = 3,
                Title = "Ultimate ASP.NET Core Web API",
                AuthorId = 3,
                Pages = 250,
                PublishYear = 2019,
                CreatedAt = DateTime.Parse("2018-05-04")
            }
        );
    }
}
