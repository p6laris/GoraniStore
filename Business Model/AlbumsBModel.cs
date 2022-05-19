using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoraniStore.Business_Model;
using GoraniStore.Model;

namespace GoraniStore.Business_Model
{
    public class AlbumsBModel
    {
        private static List<Albums> albums;

        static AlbumsBModel()
        {
            albums = new List<Albums>();
        }

        //Return all albums
        public static List<Albums> GetAlbums() => albums;

        //Return an album by a specific id

        public static List<Albums> GetAlbums(int id) => albums.Where(x => x.AlbumId == id).ToList();

        //Return an album by a specific name

        public static List<Albums> GetAlbums(string albumName) => albums.Where((x) => x.AlbumName == albumName).ToList();

        //Set an album

        public static void SetAlbum(Albums album) => albums.Add(album);

        //Delete an album by specific id
        public static void DeleteAlbum(int id) => albums.RemoveAll(x => x.AlbumId == id);

        //Delete an album by specific name

        public static void DeleteAlbum(string AlbumName) => albums.RemoveAll(x => x.AlbumName == AlbumName);

        //Update an album
        public static void ChangeAlbum(Albums oldAlbum, Albums newAlbum)
        {
            int index = albums.FindIndex(x => x.AlbumId == oldAlbum.AlbumId);

            if (index == -1)
                return;
            else
                albums[index] = newAlbum;
        }
    }
}