using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Base;

namespace ELibrary.API.Models
{
    public class PublisherModel : ModelBase<Guid>,IModelBase
    {
        public PublisherModel()
        {
            Id = Guid.Empty;
        }
        //[RegularExpression("^((?!^isim$)[a-zA-Z '])+$", ErrorMessage = "İsim formatı yanlış.")]
        public string Name { get; set; }
        public string Character { get; set; }
        [EmailAddress(ErrorMessage = "Yanlış email formatı")]
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
