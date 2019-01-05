using ELibrary.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models.Enum
{
    public class Enum : SingletonBase<Enum>
    {
        public enum Module
        {
            BookThumbnail = 1001,
            UserThumbnail = 1002,
            AuthorThumbnail = 1003,
            Publication = 1004
        }
    }
}
