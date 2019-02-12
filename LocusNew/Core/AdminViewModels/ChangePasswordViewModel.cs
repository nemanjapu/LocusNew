using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class ChangePasswordViewModel
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Molimo unesite trenutnu lozinku.")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Molimo unesite novu lozinku.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Lozinke nisu identične!")]
        public string PasswordRepeated { get; set; }
    }
}