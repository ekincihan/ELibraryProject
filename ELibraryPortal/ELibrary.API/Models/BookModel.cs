using AutoMapper;
using ELibrary.API.Base;
using ELibrary.API.Configuration;
using ELibrary.DAL.Abstract;
using ELibrary.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ELibrary.API.Models
{
    public class BookModel : ModelBase<Guid>, IModelBase
    {

        public BookModel()
        {
           
            Id = Guid.Empty;
        }

        public string Name { get; set; }
        public string BookSummary { get; set; }
        public Guid AuthorId { get; set; }
        public string ISBN { get; set; }
        public DateTime EditionDate { get; set; }
        public int NumberPage { get; set; }
        public Base64FormattingOptions BookPhoto { get; set; }
        public bool IsActive { get; set; } = true;

        public Guid PublisherId { get; set; }
        public List<PublisherModel> Publisher { get; set; }
       
        public List<AuthorModel> AuthorModel { get; set; }

    }
}
