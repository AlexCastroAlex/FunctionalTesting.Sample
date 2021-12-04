using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMapper.Samples.Models
{
    public class BookModel
    {
        [Key]
        public int BookId
        {
            get; set;
        }
        public string? BookTitle
        {
            get; set;
        }

        [ForeignKey("Author")]
        public int? AuthorId
        {
            get;set;
        }

        public virtual AuthorModel Author
        {
            get; set;
        }
    }
}
