using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore.Models;
using MVCMusicStoreClasses;

namespace MVCMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();

        //
        // GET: /StoreManager/

        public ActionResult Index(string sort = "")
        {
            var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist);
            List<Album> albumList;
            switch (sort) {
                    case "Title":
                        albumList = albums.OrderBy(a => a.Title).ToList();
                        break;
                    case "Genre":
                        albumList = albums.OrderBy(a => a.Genre.Name).ToList();
                        break;
                    case "Artist":
                        albumList = albums.OrderBy(a => a.Artist.Name).ToList();
                        break;
                    default:
                        albumList = albums.OrderBy(a => a.Price).ToList();
                        break;
                }
                
            return View(albumList);
        }

        public ActionResult Search(string q) {
            var albumList = db.Albums
                                .Include("Artist").Include("Genre")
                                .Where(a => a.Title.Contains(q) ||
                                            a.Artist.Name.Contains(q))
                                .Take(10);

            return View("Index", albumList.ToList());

        }

        //
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name");
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", album.GenreID);
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", album.ArtistID);
            return View(album);
        }

        //
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", album.GenreID);
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", album.ArtistID);
            return View(album);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", album.GenreID);
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", album.ArtistID);
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}