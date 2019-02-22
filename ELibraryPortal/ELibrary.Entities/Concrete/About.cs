using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.Entites;

namespace ELibrary.Entities.Concrete
{
    public class About : EntityBase<Guid>
    {
        public string  Contnent { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
    }
}
