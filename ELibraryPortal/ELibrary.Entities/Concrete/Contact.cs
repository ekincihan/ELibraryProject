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
    }
}
