using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GoraniStore.Model
{
    public class Albums
    {
        [Key]
        public int AlbumId { get; set; }

        public string AlbumName { get; set; }
        public DateTime DateReleased { get; set; }

        //Froign Key for artist
        public int ArtistsId { get; set; }

        public Artists Artists { get; set; }

        //Forign Key for Genre
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}