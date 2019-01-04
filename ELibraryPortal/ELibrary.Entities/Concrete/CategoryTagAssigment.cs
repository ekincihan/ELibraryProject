using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.Entites;
using MongoDB.Bson;

namespace ELibrary.Entities.Concrete
{
    public class CategoryTagAssigment : MongoEntityBase<ObjectId>
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SignUrl { get; set; }
        public string BookName { get; set; }
        public string BookSummary { get; set; }
        public string ISBN { get; set; }
        public int LangCode { get; set; }
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public List<Guid> Tags { get; set; }
    }

}
