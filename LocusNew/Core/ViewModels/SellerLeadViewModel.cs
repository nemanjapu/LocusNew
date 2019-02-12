using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocusNew.Core.ViewModels
{
    public class SellerLeadViewModel
    {
        [Required(ErrorMessage = "Ime i prezime je obavezno polje!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Telefon je obavezno polje!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Neispravan broj telefona.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email je obavezno polje!")]
        [EmailAddress(ErrorMessage = "Neispravna email adresa")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kvadratura je obavezno polje!")]
        public int SquareMeters { get; set; }
        public IEnumerable<PropertyType> PropertyTypes { get; set; }
        [Required(ErrorMessage = "Tip nekretnine je obavezno polje!")]
        public int PropertyTypeId { get; set; }
        [Required(ErrorMessage = "Adresa je obavezno polje!")]
        public string Address { get; set; }
        public bool Elevator { get; set; }
        public bool Balcony { get; set; }
        [Required(ErrorMessage = "Tražena cijena je obavezno polje!")]
        public decimal FeeWanted { get; set; }
        public int Floor { get; set; }
        public bool IsSelling { get; set; }
        public bool IsRepurchasing { get; set; }
    }
}