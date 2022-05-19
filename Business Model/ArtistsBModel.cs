using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoraniStore.Model;

namespace GoraniStore.Business_Model
{
    public class ArtistsBModel
    {
        private static List<Artists> Artists;

        static ArtistsBModel()
        {
            Artists = new List<Artists>();
        }

        //Return all artists
        public static List<Artists> GetArtists() => Artists;

        //Return an artist by a specific id

        public static List<Artists> GetArtists(int id) => Artists.Where(x => x.ArtistId == id).ToList();

        //Return an artist by a specific name
        public static List<Artists> GetArtists(string artistName) => Artists.Where(x => x.ArtistName == artistName).ToList();

        //Set Artist
        public static void SetArtist(Artists artist) => Artists.Add(artist);

        //Delete an artist by a specific id
        public static void DeleteArtist(int id) => Artists.RemoveAll(x => x.ArtistId == id);

        //Delete an artist by a specific name

        public static void DeleteArtist(string artistName) => Artists.RemoveAll(x => x.ArtistName == artistName);

        //Update an artist
        public static void ChangeArtist(Artists oldArtist, Artists newArtist)
        {
            int index = Artists.FindIndex(x => x.ArtistId == oldArtist.ArtistId);
            if (index == -1)
                return;
            else
                Artists[index] = newArtist;
        }
    }
}