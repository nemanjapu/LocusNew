using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocusNew.Core.Models
{
    public class GlobalSettings
    {
        public int Id { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string AboutUs { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string PinterestLink { get; set; }
        public string GooglePlusLink { get; set; }
        public string LinkedinLink { get; set; }
        public string YoutubeLink { get; set; }
        public int CityPart1Id { get; set; }
        public string CityPart1Image { get; set; }
        public string Image1path { get; set; }
        public int CityPart2Id { get; set; }
        public string CityPart2Image { get; set; }
        public string Image2path { get; set; }
        public int CityPart3Id { get; set; }
        public string CityPart3Image { get; set; }
        public string Image3path { get; set; }
        public int CityPart4Id { get; set; }
        public string CityPart4Image { get; set; }
        public string Image4path { get; set; }
        public int CityPart5Id { get; set; }
        public string CityPart5Image { get; set; }
        public string Image5path { get; set; }
        public int CityPart6Id { get; set; }
        public string CityPart6Image { get; set; }
        public string Image6path { get; set; }
        public string FaxNumber { get; set; }
    }
}