using AutoFixture;
using AutoMapper.Samples.DbContext;
using AutoMapper.Samples.DTO;
using AutoMapper.Samples.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTesting.Sample
{
    public class FunctionalTesting1
    {

        public FunctionalTesting1()
        {
        }
        [Fact]
        public async void Test1()
        {
            await using var application = new FunctionalTestingApp();

            var client = application.CreateClient();
            var book = await client.GetFromJsonAsync<BookSimpleDTO>("/BookSimpleDTO");
            Assert.IsType<BookSimpleDTO>(book);
            Assert.NotEqual(null, book);
            Assert.Equal(1, book.BookId);
        }

    }

    
}