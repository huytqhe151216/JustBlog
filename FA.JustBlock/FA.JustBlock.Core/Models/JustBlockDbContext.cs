using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace FA.JustBlock.Core.Models
{
    public class JustBlockDbContext : DbContext
    {
        public JustBlockDbContext()
        {

        }

        public JustBlockDbContext(DbContextOptions<JustBlockDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-0L5O0B2\\HUYSQL; database=JustBlog; user= sa; password= 12345678; TrustServerCertificate=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTagMap",
                    j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                    j => j.HasOne<Post>().WithMany().HasForeignKey("PostId"));
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            // init data for Category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "ASP.NET",
                    UrlSlug = "asp-net",
                    Description = "ASP.NET Category",
                },
                new Category
                {
                    Id = 2,
                    Name = "C#",
                    UrlSlug = "c-sharp",
                    Description = "C# Category",

                },
                new Category
                {
                    Id = 3,
                    Name = "SQL Server",
                    UrlSlug = "sql-server",
                    Description = "Description"
                }

                );
            // init data for Tag
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Name = "ASP.NET",
                    UrlSlug = "asp-net",
                    Description = "ASP.NET Tag",
                    Count = 1
                },
                new Tag
                {
                    Id = 2,
                    Name = "C#",
                    UrlSlug = "c-sharp",
                    Description = "C# Tag",
                    Count = 2
                },
                new Tag
                {
                    Id = 3,
                    Name = "SQL Server",
                    UrlSlug = "sql-server",
                    Description = "Description",
                    Count = 3

                }
             );


            // init data for Post   
            modelBuilder.Entity<Post>().HasData(
               new Post
               {
                   Id = 1,
                   Title = "ASP.NET MVC",
                   ShortDescription = "ASP.NET MVC Short Description",
                   PostContent = "ASP.NET MVC Post Content",
                   UrlSlug = "asp-net-mvc",
                   Published = true,
                   PostedOn = System.DateTime.Now,
                   CategoryId = 1,

               },
                new Post
                {
                    Id = 2,
                    Title = "ASP.NET API",
                    ShortDescription = "ASP.NET API Short Description",
                    PostContent = "ASP.NET API Post Content",
                    UrlSlug = "asp-net-api",
                    Published = true,
                    PostedOn = System.DateTime.Now,
                    CategoryId = 1

                },
                new Post
                {
                    Id = 3,
                    Title = "Title",
                    ShortDescription = " Short Description",
                    PostContent = " Post Content",
                    UrlSlug = "asp-net",
                    Published = false,
                    PostedOn = System.DateTime.Now,
                    CategoryId = 1
                }
              );
            //init for many to many relationship
            modelBuilder.Entity("PostTagMap").HasData(
                new { PostId = 1, TagId = 1 },
                new { PostId = 1, TagId = 2 },
                new { PostId = 2, TagId = 1 }
            );
        }
    }
}
