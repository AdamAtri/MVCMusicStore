using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreDB db = new MusicStoreDB();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the Music Store";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sample() {
            return View();
        }

        public ActionResult Search(string q) {
            var albums = db.Albums
                            .Include("Artist")
                            .Where(a => a.Title.Contains(q))
                            .Take(10);

            return View(albums.ToList());
        }
    }
}
