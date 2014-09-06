using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreClasses
{
    public class Song
    {
        public string Title { get; set; }
        public string SongPath { get; set; }
    }

    public static class StringExtensions
    {

        public static string CapitalizeFirst(this string original)
        {
            string result = "";
            string[] parts = original.Split(' ');
            foreach (string part in parts)
            {
                string first = part[0].ToString();
                result += first.ToUpper() + part.Substring(1) + " ";
            }
            return result.Trim();
        }
    }
}