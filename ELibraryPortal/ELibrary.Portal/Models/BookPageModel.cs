using ELibrary.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Portal.Models
{
    public class BookPageModel
    {
        public List<BookModel> BookList { get; set; }
        public List<PublisherModel> PubLisherList { get; set; }
        public List<AuthorModel> AuthorList { get; set; }
        public BookModel bookModel { get; set; }

    }
}
