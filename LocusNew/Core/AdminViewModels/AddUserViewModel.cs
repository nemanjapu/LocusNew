using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class AddUserViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Ime je obavezno polje!")]
        [DisplayName("Ime")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno polje!")]
        [DisplayName("Prezime")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email je obavezno polje!")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Broj telefona je obavezno polje!")]
        [DisplayName("Broj telefona")]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Lozinke nisu identične!")]
        public string PasswordRepeated { get; set; }
        public bool isAdmin { get; set; }
        public bool isAgent { get; set; }
        public bool isActive { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string ImageName { get; set; }
        public string Designation { get; set; }

        public HttpPostedFileBase AgentCardFile { get; set; }
        public string AgentCardImageName { get; set; }

        public AddUserViewModel()
        {
            ImageName = "/Areas/Admin/Content/Images/upload-icon.png";
            AgentCardImageName = "/Areas/Admin/Content/Images/upload-icon.png";
        }
    }
}