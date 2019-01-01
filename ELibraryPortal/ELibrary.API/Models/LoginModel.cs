using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELibrary.API.Models
{
    public class LoginModel
    {
        //[Required]
        //public string Username { get; set; }
        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Lütfen Email Giriniz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
