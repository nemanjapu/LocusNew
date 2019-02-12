using LocusNew.Core.ViewModels;
using LocusNew.Core.Models;
using LocusNew.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Text;
using System.Xml.Linq;
using System.Globalization;
using System.Web.SessionState;
using AutoMapper;
using LocusNew.Core;

namespace LocusNew.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Sitemap

        public class SitemapNode
        {
            public SitemapFrequency? Frequency { get; set; }
            public DateTime? LastModified { get; set; }
            public double? Priority { get; set; }
            public string Url { get; set; }
        }

        public enum SitemapFrequency
        {
            Never,
            Yearly,
            Monthly,
            Weekly,
            Daily,
            Hourly,
            Always
        }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(UrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            nodes.Add(
                new SitemapNode()
                {
                    Url = "https://www.locus.ba/",
                    Priority = 1,
                    Frequency = SitemapFrequency.Daily
                });
            nodes.Add(
               new SitemapNode()
               {
                   Url = "https://www.locus.ba/search",
                   Priority = 1,
                   Frequency = SitemapFrequency.Daily
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = "https://www.locus.ba/selling/repurchase",
                   Priority = 1,
                   Frequency = SitemapFrequency.Monthly
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = "https://www.locus.ba/aboutus",
                   Priority = 1,
                   Frequency = SitemapFrequency.Monthly
               });
            nodes.Add(
              new SitemapNode()
              {
                  Url = "https://www.locus.ba/search/sold",
                  Priority = 1,
                  Frequency = SitemapFrequency.Weekly
              });
            var items = _unitOfWork.Listings.GetListings().Select(l => new
            {
                ID = l.Id
            }).ToList();
            foreach (var item in items)
            {
                nodes.Add(
                   new SitemapNode()
                   {
                       Url = "https://www.locus.ba/search/listing/" + item.ID,
                       Frequency = SitemapFrequency.Weekly,
                       Priority = 1
                   });
            }

            return nodes;
        }

        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }

        public ActionResult SitemapXml()
        {
            var sitemapNodes = GetSitemapNodes(this.Url);
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "xml", Encoding.UTF8);
        }

        #endregion

        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                Listings = _unitOfWork.Listings.GetListingsWithCityAndAdType()
                .Where(l => l.isActive == true)
                .OrderByDescending(l => l.AdType.Name == "Oglas")
                .ThenByDescending(l => l.Published)
                .AsNoTracking()
                .Take(10)
                .Select(Mapper.Map<Listing, ListingsListViewModel>).AsEnumerable(),
                GlobalSettings = Mapper.Map<HomeGlobalSettingsViewModel>(_unitOfWork.GlobalSettings.GetGlobalSettings())
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string SendMessage(HomeViewModel model)
        {
            var m = Mapper.Map<Lead>(model.Message);
            _unitOfWork.Leads.AddLead(m);
            _unitOfWork.Complete();

            EmailSender.SendEmail(model.Message, null, null, null, null);

            string message = "Hvala Vam na vašoj poruci!";

            return message;
        }
    }
}