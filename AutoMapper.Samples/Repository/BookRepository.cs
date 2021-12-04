using AutoMapper.QueryableExtensions;
using AutoMapper.Samples.DbContext;
using AutoMapper.Samples.DTO;
using AutoMapper.Samples.Models;
using System.Data.Entity;
using System.Linq;

namespace AutoMapper.Samples.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DBContext _dbContext;
        public BookRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<BookModel> GetBooks()
        {
            return _dbContext.Books?.OrderByDescending(book => book.BookId);
        }

        public BookModel GetBook(int id)
        {
            _dbContext.Authors.Load();
            return _dbContext.Books.Include(c => c.Author).FirstOrDefault(book => book.BookId == id);
        }

        public IQueryable<BookModel> GetBookQueryable(int id)
        {
            _dbContext.Authors.Load();
            return _dbContext.Books.Where(book => book.BookId == id).AsQueryable();
        }

    }
}
