using AutoMapper;
using AutoMapper.Samples.DbContext;
using AutoMapper.Samples.DTO;
using AutoMapper.Samples.Models;
using AutoMapper.Samples.Profiles;
using AutoMapper.Samples.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.CreateMap<BookModel, BookSimpleDTO>();
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IBookRepository, BookRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/BookSimpleDTO", (IBookRepository _bookRepository, IMapper mapper) =>
{

    var result = _bookRepository.GetBook(1);
    var destination = mapper.Map<BookModel, BookSimpleDTO>(result);
    return destination;
})
.WithName("GetBookSimpleDTO");

app.MapGet("/BookFullDTO", (IBookRepository _bookRepository, IMapper mapper) =>
{
    var result = _bookRepository.GetBook(1);
    var destination = mapper.Map<BookModel, BookFullDTO>(result);
    return destination;
})
.WithName("BookFullDTO");

app.MapGet("/GetBookFullDTOWithProject", (IBookRepository _bookRepository, IMapper mapper) =>
{
    var result = _bookRepository.GetBookQueryable(1);
    var destination = mapper.ProjectTo<BookFullDTO>(result);
    return destination;
})
.WithName("GetBookFullDTOWithProject");

app.Run();

public partial class Program
{
    // Expose the Program class for use with WebApplicationFactory<T>
}