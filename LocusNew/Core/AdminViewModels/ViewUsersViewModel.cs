using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.AdminViewModels
{
    public class ViewUsersViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int NumberOfListings { get; set; }
    }
}