using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
