using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace LocusNew.Helpers
{
    public class HTMLhelpers
    {
        public static IHtmlString ListingInfo(string name, bool model)
        {
            if (model)
            {
                return MvcHtmlString.Create("<div class='col-xl-4 p-0'><div class='list-group-item d-flex justify-content-between align-items-center'>" + name +
                "<span class='badge'><i class='fas fa-check-circle'></i></span></div></div>");
            }
            else
            {
                return null;
            }
        }

        public static IHtmlString ListingInfoNumber(string name, int? model, bool sqMeters = false)
        {
            string sqm = "";
            if (model > 0)
            {
                if (sqMeters)
                {
                    sqm = " m<sup>2</sup>";
                }
                return MvcHtmlString.Create("<li class='list-group-item d-flex justify-content-between align-items-center'>" + name +
                    "<span class='badge'>" + model + sqm + "</span>");
            }
            return null;
        }

        public static string ListingImageName(string uploadedName)
        {
            string imgName = uploadedName.Replace("_", " ");
            imgName = Regex.Replace(imgName, @"^[\d-]*\s*", "", RegexOptions.Multiline);

            return imgName;
        }
    }
}