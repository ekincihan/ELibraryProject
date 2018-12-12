using ELibrary.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class TagModel:ModelBase<Guid>,IModelBase
    {
        public TagModel()
        {
            Id = Guid.Empty;
        }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
