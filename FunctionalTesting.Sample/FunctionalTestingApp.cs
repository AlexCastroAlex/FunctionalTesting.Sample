using AutoMapper.Samples.DbContext;
using AutoMapper.Samples.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalTesting.Sample
{
   public class FunctionalTestingApp : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<DBContext>));

                services.AddDbContext<DBContext>(options =>
                    options.UseInMemoryDatabase("Testing", root));
            });
           
            return base.CreateHost(builder).SeedDataBase();
        }
    }
    public static class MigrationManager
    {
        public static IHost SeedDataBase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var BookContext = scope.ServiceProvider.GetRequiredService<DBContext>())
                {
                    try
                    {
                        BookContext.Authors.Add(new AuthorModel
                        {
                            Id = 1,
                            FirstName = "Alexandre",
                            LastName = "Castro"

                        });
                        BookContext.Authors.Add(new AuthorModel
                        {
                            Id = 2,
                            FirstName = "Martin",
                            LastName = "Fowler"

                        });
                        BookContext.Authors.Add(new AuthorModel
                        {
                            Id = 3,
                            FirstName = "Gang",
                            LastName = "Of Four"

                        });
                        BookContext.Authors.Add(new AuthorModel
                        {
                            Id = 4,
                            FirstName = "Christophe",
                            LastName = "Mommer"

                        });

                        BookContext.Books.Add(new BookModel
                        {
                            BookId = 1,
                            BookTitle = "AutoMapper samples",
                            AuthorId = 1
                        });

                        BookContext.Books.Add(new BookModel
                        {
                            BookId = 2,
                            BookTitle = "Clean Code",
                            AuthorId = 2
                        });

                        BookContext.Books.Add(new BookModel
                        {
                            BookId = 3,
                            BookTitle = "Design patterns",
                            AuthorId = 3
                        });
                        BookContext.Books.Add(new BookModel
                        {
                            BookId = 4,
                            BookTitle = "Docker pour les développeurs .Net",
                            AuthorId = 4
                        });
                        BookContext.Books.Add(new BookModel
                        {
                            BookId = 5,
                            BookTitle = "Blazor :développement front end d'application web dynamiques",
                            AuthorId = 4
                        });

                        BookContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
