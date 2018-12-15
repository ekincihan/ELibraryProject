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
            Book = 1001,
            User = 1002
        }
    }
}
