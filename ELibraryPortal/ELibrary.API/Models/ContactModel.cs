using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class ContactModel
    {
        public ContactModel()
        {
            Id=Guid.Empty;
        }
        public Guid Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Adress { get; set; }
        public string PhonuNumber { get; set; }
        public string SiteMail { get; set; }
    }
}
