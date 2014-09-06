using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreClasses;

namespace MVCMusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public string Index()
        {
            return "Hello from Store.Index()";
        }

        public ActionResult Browse(string query = "") {
            //var message = HttpUtility.HtmlEncode(string.Format("Hello from Store.Browse({0})", query)) ;
            ViewBag.Filter = query;
            return View(getSongs(query));            
        }

        private List<Song> getSongs(string filter)
        {
            string[] songPaths = Directory.GetFileSystemEntries("E:\\Music", "*.mp3", SearchOption.AllDirectories);
            List<Song> songs = new List<Song>();
            foreach (string s in songPaths) {
                if (s.Contains(filter.ToLower()) ||
                    s.Contains(filter.ToUpper()) || 
                    s.Contains(filter.CapitalizeFirst())) {
                    
                    songs.Add(extractSong(s));
                }
            }
            return songs;

        }

        private Song extractSong(string s)
        {
           Song aSong =  new Song (); 
           aSong.SongPath = s.Substring(0,s.LastIndexOf("\\"));
           aSong.Title = s.Substring(s.LastIndexOf("\\") + 1).Replace(".mp3","");
                                    
           return aSong;
                    
        }

        public ActionResult Details(int id = -999) {

            return View();
        }

    }
}


