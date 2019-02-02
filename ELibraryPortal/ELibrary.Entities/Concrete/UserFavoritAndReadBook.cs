using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ELibrary.Core.Entites;

namespace ELibrary.Entities.Concrete
{
    public class UserFavoritAndReadBook : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId{ get; set; }
        public UserFavAndRead Type { get; set; }
    }


    public enum UserFavAndRead
    {
        [Description("Favorite")]
        Favorite = 1,
        [Description("Read")]
        Reads = 2,
    }
}
