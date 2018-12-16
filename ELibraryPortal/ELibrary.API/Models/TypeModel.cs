using ELibrary.API.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class TypeModel : ModelBase<Guid>, IModelBase
    {
        public TypeModel()
        {
            Id = Guid.Empty;
        }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
