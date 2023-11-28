using BooksAppData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksAppData;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }

    private readonly string _storagePath;

    private readonly IPasswordHasher<IdentityUser> _passwordHasher;

    public AppDbContext()
    {
        var appDataFolder = Environment.SpecialFolder.LocalApplicationData;
        var appDataPath = Environment.GetFolderPath(appDataFolder);
        _storagePath = Path.Join(appDataPath, "book_app.db");
        _passwordHasher = new PasswordHasher<IdentityUser>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={_storagePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookEntity>()
            .HasOne(book => book.Author)
            .WithMany(author => author.Books)
            .HasForeignKey(book => book.AuthorId);

        CreateIdentity(modelBuilder);
        CreateAuthors(modelBuilder);
        CreateBooks(modelBuilder);
    }

    private void CreateIdentity(ModelBuilder modelBuilder)
    {
        var adminRole = new IdentityRole { Name = "admin" };
        var userRole = new IdentityRole { Name = "user" };

        CreateRole(modelBuilder, adminRole);
        CreateRole(modelBuilder, userRole);

        var adminUser = new IdentityUser { UserName = "admin", Email = "admin@wsei.edu.pl" };
        var standardUser = new IdentityUser { UserName = "user", Email = "user@wsei.edu.pl" };

        CreateUser(modelBuilder, adminUser, "1234abcd!@#$ABCD");
        CreateUser(modelBuilder, standardUser, "zaq1@WSX");

        AssignRole(modelBuilder, adminUser, adminRole);
        AssignRole(modelBuilder, standardUser, userRole);
    }

    private void CreateRole(ModelBuilder modelBuilder, IdentityRole role)
    {
        role.NormalizedName = role.Name?.ToUpper();
        role.ConcurrencyStamp = role.Id;
        modelBuilder.Entity<IdentityRole>().HasData(role);
    }

    private void CreateUser(ModelBuilder modelBuilder, IdentityUser user, string password)
    {
        user.NormalizedUserName = user.UserName?.ToUpper();
        user.NormalizedEmail = user.Email?.ToUpper();
        user.EmailConfirmed = true;
        user.PasswordHash = _passwordHasher.HashPassword(user, password);
        modelBuilder.Entity<IdentityUser>().HasData(user);
    }

    private void AssignRole(ModelBuilder modelBuilder, IdentityUser user, IdentityRole role)
    {
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = role.Id, UserId = user.Id }
        );
    }

    private void CreateAuthors(ModelBuilder modelBuilder)
    {
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
    }

    private void CreateBooks(ModelBuilder modelBuilder)
    {
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