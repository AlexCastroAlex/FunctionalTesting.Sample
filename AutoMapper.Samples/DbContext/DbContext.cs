using AutoMapper.Samples.Models;
using Microsoft.EntityFrameworkCore;


namespace AutoMapper.Samples.DbContext
{
    public class DBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public virtual DbSet<BookModel>? Books { get; set; }
        public virtual DbSet<AuthorModel>? Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>()
                .HasOne(c => c.Author)
                .WithMany(e => e.BooksCollection)
                .HasForeignKey(c=>c.AuthorId);

            modelBuilder.Entity<AuthorModel>()
                .HasMany(c => c.BooksCollection)
                .WithOne(c => c.Author);

            modelBuilder.Entity<AuthorModel>().HasData(new AuthorModel
            {
                Id = 1,
                FirstName = "Alexandre",
                LastName = "Castro"

            });
            modelBuilder.Entity<AuthorModel>().HasData(new AuthorModel
            {
                Id = 2,
                FirstName = "Martin",
                LastName = "Fowler"

            });
            modelBuilder.Entity<AuthorModel>().HasData(new AuthorModel
            {
                Id = 3,
                FirstName = "Gang",
                LastName = "Of Four"

            });
            modelBuilder.Entity<AuthorModel>().HasData(new AuthorModel
            {
                Id = 4,
                FirstName = "Christophe",
                LastName = "Mommer"

            });

            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                BookId = 1,
                BookTitle = "AutoMapper samples",
                AuthorId =1 
            });
            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                BookId = 2,
                BookTitle = "Clean Code",
                AuthorId =2
            });
            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                BookId = 3,
                BookTitle = "Design patterns",
                AuthorId = 3
            });
            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                BookId = 4,
                BookTitle = "Docker pour les développeurs .Net",
                AuthorId = 4
            });
            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                BookId = 5,
                BookTitle = "Blazor :développement front end d'application web dynamiques",
                AuthorId = 4
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
