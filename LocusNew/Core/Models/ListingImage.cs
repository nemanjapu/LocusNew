using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocusNew.Core.Models
{
    public class ListingImage
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        public int SortOrder { get; set; }
        public string FileNameNoExt { get; set; }
        public string FilePath { get; set; }
    }
}