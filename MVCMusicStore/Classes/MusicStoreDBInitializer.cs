using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCMusicStore.Models;

namespace MVCMusicStore.Classes
{
    public class MusicStoreDBInitializer : DropCreateDatabaseIfModelChanges<MusicStoreDB>
    {
        protected override void Seed(MusicStoreDB context)
        {
            context.Albums.Add(new Album()
            {
                Title = "Appetite for Destruction",
                Artist = new Artist() { Name = "Guns N' Roses" },
                Price = 9.99m,
                Genre = new Genre() { Name = "Hard Rock / Heavy Metal" }
            });

            context.Albums.Add(new Album()
            {
                Title = "40oz. to Freedom",
                Artist = new Artist() { Name = "Sublime" },
                Price = 9.99m,
                Genre = new Genre() { Name = "Ska / Punk" }
            });

            context.Albums.Add(new Album()
            {
                Title = "Appertife for Destruction",
                Artist = new Artist() { Name = "Richard Cheese" },
                Price = 9.99m,
                Genre = new Genre() { Name = "Hard Rock / Lounge" }
            });

            context.Albums.Add(new Album()
            {
                Title = "Ill Communication",
                Artist = new Artist() { Name = "Beastie Boys" },
                Price = 9.99m,
                Genre = new Genre() { Name = "Rap / Punk" }
            });

            context.Albums.Add(new Album()
            {
                Title = "Live from San Quentin",
                Artist = new Artist() { Name = "Johnny Cash" },
                Price = 9.99m,
                Genre = new Genre() { Name = "Country" }
            });

            context.Albums.Add(new Album()
            {
                Title = "Are You Experienced?",
                Artist = new Artist() { Name = "Jimi Hendrix Experienced" },
                Price = 9.99m,
                Genre = new Genre() { Name = "Hard Rock / Pychedelic" }
            });

            context.Albums.Add(new Album()
            {
                Title = "Brain Cycles",
                Artist = new Artist() { Name = "Radiow Moscow" },
                Price = 9.99m,
                Genre = new Genre() { Name = "Hard Rock / Pychedelic" }
            });

            context.Genres.Add(new Genre() {Name = "Jazz"});
            context.Genres.Add(new Genre() { Name = "Classical" });
            context.Genres.Add(new Genre() { Name = "R & B" });
            context.Genres.Add(new Genre() { Name = "World" });
            context.Genres.Add(new Genre() { Name = "Pop" });


            base.Seed(context);


        }
    }
}