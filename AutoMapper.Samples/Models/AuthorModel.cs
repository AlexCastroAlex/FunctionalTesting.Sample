using System.ComponentModel.DataAnnotations;

namespace AutoMapper.Samples.Models
{
    public class AuthorModel
    {
        [Key]
        public int Id
        {
            get; set;
        }
        public string? FirstName
        {
            get; set;
        }
        public string? LastName
        {
            get; set;
        }

        public virtual ICollection<BookModel> BooksCollection { get; set; }
    }
}
