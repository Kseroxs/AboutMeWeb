using System;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using Szymon.Models;

namespace Szymon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string url = "http://www.rssmix.com/u/12834899/rss.xml")
        {
            var items = XElement.Load(url).Descendants("item").Select(i => new RssItem
            {
                Title = i.Element("title").Value,
                PubDate = i.Element("pubDate").Value,
                Description = i.Element("description").Value
            }).ToList().Take(4);

            return View(items);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}