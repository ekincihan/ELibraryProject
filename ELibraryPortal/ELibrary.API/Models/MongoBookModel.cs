using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class MongoBookModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SignUrl { get; set; }
        public string BookName { get; set; }
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public List<Guid> Tags { get; set; }
    }
}
