using ELibrary.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class BookUIModel : ModelBase<Guid>, IModelBase
    {
        public string BookName { get; set; }
        public string BookSummary { get; set; }
        public Guid AuthorId { get; set; }
        public string ISBN { get; set; }
        public DateTime EditionDate { get; set; }
        public int NumberPages { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid PublisherId { get; set; }
        public AuthorModel Author { get; set; }
        public PublisherModel Publisher { get; set; }
        public int ReadCount { get; set; }
        public AppFileModel Thumbnail { get; set; }
        public ICollection<AppFileModel> AppFiles { get; set; }
    }
}
