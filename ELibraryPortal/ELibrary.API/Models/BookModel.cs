using ELibrary.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class BookModel:ModelBase<Guid>,IModelBase
    {
        public BookModel()
        {
            Id = Guid.Empty;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public string BookSummary { get; set; }
        public string ISBN { get; set; }
        public DateTime EditionDate { get; set; }
        public int NumberPage { get; set; }
        public Base64FormattingOptions BooksPhoto { get; set; }
        public bool IsActive { get; set; }

        public PublisherModel publisherModel { get; set; }

      
    }
}
