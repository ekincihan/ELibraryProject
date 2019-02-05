using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using ELibrary.DAL.Abstract;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;

namespace ELibrary.API.Controllers
{
    [Route("api/Search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMongoTagCategoryAssigment _mongoTagCategory;

        public SearchController(IMongoTagCategoryAssigment mongoTagCategory)
        {
            _mongoTagCategory = mongoTagCategory;
        }

        [HttpGet("Get")]
        public SearchModel Result(string searchKey)
        {
            SearchModel model = new SearchModel();
            List<AuthorSearchModel> authors = new List<AuthorSearchModel>();
            List<BookSearchModel> books = new List<BookSearchModel>();
            List<PublisherModel> publishers = new List<PublisherModel>();

            List<CategoryTagAssigment> entity = _mongoTagCategory.Search(searchKey);
            foreach (var item in entity)
            {
                AuthorSearchModel author = new AuthorSearchModel();
                BookSearchModel book = new BookSearchModel();
                PublisherModel publisher = new PublisherModel();

                author.Id = item.AuthorId;
                author.Name = item.AuthorName + item.AuthorSurname;

                book.Id = item.BookId;
                book.Name = item.BookName;

                publisher.Id = item.PublisherId;
                publisher.Name = item.PublisherName;

                authors.Add(author);
                books.Add(book);
                publishers.Add(publisher);
            }

            model.Authors = authors.GroupBy(x=>x.Id).Select(x=>x.First()).ToList();
            model.Books = books.GroupBy(x => x.Id).Select(x => x.First()).ToList();
            model.Publishers = publishers.GroupBy(x => x.Name).Select(x => x.First()).ToList();

            return model;
        }
    }
}