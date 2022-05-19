using GoraniStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraniStore.Business_Model
{
    public class GenreBModel
    {
        public static List<Genre> Genres;

        static GenreBModel()
        {
            Genres = new List<Genre>();
        }

        //Return all Genres
        public static List<Genre> GetGenre() => Genres;

        //Return a genre by a sepesific genre id
        public static List<Genre> GetGenre(int id) => Genres.Where(x => x.GenreId == id).ToList();

        //Return a genre by a sepesific genre name
        public static List<Genre> GetGenre(string gName) => Genres.Where(x => x.GenreName == gName).ToList();

        //Create a genre
        public static void SetGenre(Genre genre) => Genres.Add(genre);

        //Delete a genre by a sepesific genre id
        public static void DeleteGenre(int id) => Genres.RemoveAll(x => x.GenreId == id);

        //Delete a genre by a sepesific genre name
        public static void DeleteGenre(string gName) => Genres.RemoveAll(x => x.GenreName == gName);

        //Modify a genre's name by a sepesific id
        public static void ChangeGenre(Genre oldGenre, Genre newGenre)
        {
            int index = Genres.FindIndex(x => x.GenreId == oldGenre.GenreId);

            if (index == -1)
                return;
            else
                Genres[index] = newGenre;
        }
    }
}