using ELibrary.API.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class Type : ModelBase<Guid>, IModelBase
    {
        public Type()
        {
            Id = Guid.Empty;
        }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
