using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocusNew.Core.ViewModels
{
    public class LeadViewModel
    {
        [Required(ErrorMessage = "Ima i prezime je obavezno polje!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail je obavezno polje!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Broj telefona je obavezno polje!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Poruka je obavezno polje!")]
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}