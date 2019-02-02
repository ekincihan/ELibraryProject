using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Portal.Models
{
    public class SessionModel
    {
        public string BookName { get; set; }
        public string BookSummary { get; set; }
        public int NumberPages { get; set; }
        public string PublisherVal { get; set; }
        public string PublisherText { get; set; }
        public string AuthorVal { get; set; }
        public string AuthorText { get; set; }
    }
}
