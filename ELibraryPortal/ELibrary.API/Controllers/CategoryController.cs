using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ELibrary.API.Base;
using ELibrary.DAL.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.API.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : APIControllerBase
    {
        private readonly ICategory _category;
        public IMapper _mapper;

        public CategoryController(ICategory category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }
    }
}