using AutoMapper.Samples.Models;

namespace AutoMapper.Samples.Repository
{
    public interface IBookRepository
    {
        BookModel GetBook(int id);
        IEnumerable<BookModel> GetBooks();
        IQueryable<BookModel> GetBookQueryable(int id);
    }
}