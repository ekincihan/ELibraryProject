using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Base;

namespace ELibrary.API.Models
{
    public class BannerModel : ModelBase<Guid>,IModelBase
    {
        public BannerModel()
        {
            Id = Guid.Empty;
        }
        public string Name { get; set; }
        public string SendUrl { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
