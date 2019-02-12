using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocusNew.Core.ViewModels
{
    public class BookAShowingViewModel
    {
        [Required(ErrorMessage = "Ime je obavezno polje!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno polje!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email je obavezno polje!")]
        [EmailAddress(ErrorMessage = "Neispravna email adresa")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon je obavezno polje!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Neispravan broj telefona.")]
        public string Phone { get; set; }
        public string DateSubmited { get; set; }
        [Required(ErrorMessage = "Datum je obavezno polje!")]
        public string DateForShowing { get; set; }
        public int ListingId { get; set; }
        public string ApplicationUserId { get; set; }

        public BookAShowingViewModel()
        {
            DateForShowing = DateTime.Now.ToString("dd.MM.yyyy");
        }
    }
}