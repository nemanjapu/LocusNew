using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocusNew.Core.AdminViewModels
{
    public class GlobalSettingsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [AllowHtml]
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
        public HttpPostedFileBase File1 { get; set; }
        public int CityPart2Id { get; set; }
        public string CityPart2Image { get; set; }
        public HttpPostedFileBase File2 { get; set; }
        public int CityPart3Id { get; set; }
        public string CityPart3Image { get; set; }
        public HttpPostedFileBase File3 { get; set; }
        public int CityPart4Id { get; set; }
        public string CityPart4Image { get; set; }
        public HttpPostedFileBase File4 { get; set; }
        public int CityPart5Id { get; set; }
        public string CityPart5Image { get; set; }
        public HttpPostedFileBase File5 { get; set; }
        public int CityPart6Id { get; set; }
        public string CityPart6Image { get; set; }
        public HttpPostedFileBase File6 { get; set; }
        public string FaxNumber { get; set; }
        public IEnumerable<CityPart> CityParts { get; set; }
    }
}