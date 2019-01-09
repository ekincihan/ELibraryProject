using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.Entites;
using MongoDB.Bson;

namespace ELibrary.Entities.Concrete
{
    public class UsersFavoritesAndReads : MongoEntityBase<ObjectId>
    {
        public Guid AuthorId { get; set; }
        public List<MongoBook> Favorites { get; set; }
        public List<MongoBook> Reads { get; set; }
    }

    public class MongoBook
    {
        public int Rate { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid BookId { get; set; }
        public string SignUrl { get; set; }
        public string BookName { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }

    }

}
