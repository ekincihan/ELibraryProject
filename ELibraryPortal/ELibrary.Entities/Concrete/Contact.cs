using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.Entites;

namespace ELibrary.Entities.Concrete
{
    public class Contact : EntityBase<Guid>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Adress { get; set; }
        public string PhonuNumber { get; set; }
        public string SiteMail { get; set; }
        public int Type { get; set; }
    }
}
