using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class SellerLeadsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int SquareMeters { get; set; }
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public int Floor { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public bool Elevator { get; set; }
        public bool Balcony { get; set; }
        public decimal FeeWanted { get; set; }
        public bool IsSelling { get; set; }
        public bool IsRepurchasing { get; set; }
    }
}