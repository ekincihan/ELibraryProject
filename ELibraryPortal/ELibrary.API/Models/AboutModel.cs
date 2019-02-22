﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Base;

namespace ELibrary.API.Models
{
    public class AboutModel : ModelBase<Guid>, IModelBase
    {
        public AboutModel()
        {
            Id = Guid.Empty;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}
 