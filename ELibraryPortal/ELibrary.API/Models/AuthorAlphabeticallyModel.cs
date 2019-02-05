using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class AuthorAlphabeticallyModel
    {
        public AuthorAlphabeticallyModel()
        {
            AlphabeticalList = new List<AuthorBasicModel>();
        }
        //[RegularExpression("^((?!^isim$)[a-zA-Z '])+$", ErrorMessage = "İsim formatı yanlış.")]
        public string Character { get; set; }
        public List<AuthorBasicModel> AlphabeticalList { get; set; }
    }
}
