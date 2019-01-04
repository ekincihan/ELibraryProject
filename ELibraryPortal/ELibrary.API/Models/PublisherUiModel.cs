using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Models
{
    public class PublisherUiModel
    {
        public PublisherUiModel()
        {
            AlphabeticalList = new List<PublisherModel>();
        }
        //[RegularExpression("^((?!^isim$)[a-zA-Z '])+$", ErrorMessage = "İsim formatı yanlış.")]
        public string Character { get; set; }
        public List<PublisherModel> AlphabeticalList { get; set; }
    }
}
