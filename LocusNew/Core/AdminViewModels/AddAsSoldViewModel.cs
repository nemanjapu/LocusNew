using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class AddAsSoldViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ime je obavezno polje.")]
        [DisplayName("Ime")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno polje.")]
        [DisplayName("Prezime")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Broj telefona je obavezno polje.")]
        [DisplayName("Broj telefona")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IdNumber { get; set; }
        public int ListingId { get; set; }
    }
}