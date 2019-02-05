using System;
using System.Collections.Generic;
using System.Text;
using ELibrary.Core.Entites;

namespace ELibrary.Entities.Concrete
{
    public class UserReadPage : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public int Page { get; set; }
    }
}
