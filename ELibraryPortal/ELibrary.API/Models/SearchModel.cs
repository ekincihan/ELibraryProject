using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class SearchModel
    {
        public List<PublisherModel> Publishers { get; set; }
        public List<AuthorSearchModel> Authors { get; set; }
        public List<BookSearchModel> Books { get; set; }
    }

    public class AuthorSearchModel
    {
        public Guid Id { get; }
        public string Name { get; }
    }

    public class BookSearchModel
    {
        public Guid Id { get; }
        public string Name { get; }
    }
}
