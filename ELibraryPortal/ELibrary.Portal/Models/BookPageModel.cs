using ELibrary.API.Models;
using Microsoft.AspNetCore.Http;
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
        public List<CategoryModel> CategoryList { get; set; }
        public List<TagModel> TagList { get; set; }
        public BookModel bookModel { get; set; }
        public IFormFile Thumbnail { get; set; }
        public IFormFile Publication { get; set; }
    }
}
