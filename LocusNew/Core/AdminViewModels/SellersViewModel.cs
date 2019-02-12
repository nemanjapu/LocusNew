﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class SellersViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IdNumber { get; set; }
    }
}