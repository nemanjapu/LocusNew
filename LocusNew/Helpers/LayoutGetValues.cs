using LocusNew.Persistence;
using LocusNew.Core.Models;
using System.Linq;

namespace LocusNew.Helpers
{
    public class LayoutGetValues
    {
        protected static ApplicationDbContext ctx = new ApplicationDbContext();

        private static GlobalSettings Global = ctx.GlobalSettings.AsNoTracking().FirstOrDefault();

        #region PhoneEmailAddress 
        public static string GetEmail()
        {
            return Global.Email;
        }
        public static string GetPhone()
        {
            return Global.PhoneNumber;
        }
        public static string GetAddress()
        {
            return Global.Address;
        }
        #endregion

        #region SocialMedia
        public static string GetFacebook()
        {
            return Global.FacebookLink;
        }
        public static string GetInstagram()
        {
            return Global.InstagramLink;
        }
        public static string GetTwitter()
        {
            return Global.TwitterLink;
        }
        public static string GetPinterest()
        {
            return Global.PinterestLink;
        }
        public static string GetGooglePlus()
        {
            return Global.GooglePlusLink;
        }
        public static string GetLinkedin()
        {
            return Global.LinkedinLink;
        }
        public static string GetYoutube()
        {
            return Global.YoutubeLink;
        }
        #endregion

        #region CityPartsHomepageNames

        public static string CityPart1Name()
        {
            return ctx.CityPart.Find(Global.CityPart1Id).Name;
        }

        public static string CityPart2Name()
        {
            return ctx.CityPart.Find(Global.CityPart2Id).Name;
        }

        public static string CityPart3Name()
        {
            return ctx.CityPart.Find(Global.CityPart3Id).Name;
        }

        public static string CityPart4Name()
        {
            return ctx.CityPart.Find(Global.CityPart4Id).Name;
        }

        public static string CityPart5Name()
        {
            return ctx.CityPart.Find(Global.CityPart5Id).Name;
        }

        public static string CityPart6Name()
        {
            return ctx.CityPart.Find(Global.CityPart6Id).Name;
        }

        #endregion

        #region CityPartsHomepageImages

        public static string CityPart1Image()
        {
            return "/DynamicContent/CityPartsHomepage/" + Global.CityPart1Image;
        }

        public static string CityPart2Image()
        {
            return "/DynamicContent/CityPartsHomepage/" + Global.CityPart2Image;
        }

        public static string CityPart3Image()
        {
            return "/DynamicContent/CityPartsHomepage/" + Global.CityPart3Image;
        }

        public static string CityPart4Image()
        {
            return "/DynamicContent/CityPartsHomepage/" + Global.CityPart4Image;
        }

        public static string CityPart5Image()
        {
            return "/DynamicContent/CityPartsHomepage/" + Global.CityPart5Image;
        }

        public static string CityPart6Image()
        {
            return "/DynamicContent/CityPartsHomepage/" + Global.CityPart6Image;
        }

        #endregion

        public static string GetListingsNumberForCities(int CityId)
        {
            string num = ctx.Listing.Where(nl => nl.CityPartId == CityId && nl.isActive == true && nl.isSold == false).AsQueryable().Count().ToString();

            return num;
        }
    }
}