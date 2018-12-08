using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Models;
using ELibrary.Entities.Concrete;

namespace ELibrary.API.Helpers
{
    public class AutoMapperHelper:Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<PublisherModel, Publisher>();
            CreateMap<Publisher, PublisherModel>();
        }
    }
}
