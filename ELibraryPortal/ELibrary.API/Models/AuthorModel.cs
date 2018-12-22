using ELibrary.API.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class AuthorModel : ModelBase<Guid>, IModelBase
    {
        public AuthorModel()
        {
            Id = Guid.Empty;
        }
        [Required]
        [RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "İsim formatı yanlış.")]
        public string Name { get; set; }
        [RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "Soy isim formatı yanlış.")]
        public string Surname { get; set; }
        public string Biography { get; set; }
        public int Gender { get; set; }
        public Base64FormattingOptions AuthorPhoto { get; set; }
        public ICollection<BookModel> Books { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
