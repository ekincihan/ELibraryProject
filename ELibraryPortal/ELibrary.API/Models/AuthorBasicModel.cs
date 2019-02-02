using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class AuthorBasicModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
