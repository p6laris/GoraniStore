using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoraniStore.Business_Model;
using GoraniStore.Model;

namespace GoraniStore
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Genre

            GenreBModel.SetGenre(new Genre() { GenreId = 1, GenreName = "Classic" });
            GenreBModel.SetGenre(new Genre() { GenreId = 2, GenreName = "Jazz" });
            GenreBModel.SetGenre(new Genre() { GenreId = 3, GenreName = "Folk" });
            GenreBModel.SetGenre(new Genre() { GenreId = 4, GenreName = "Pop" });
            GenreBModel.SetGenre(new Genre() { GenreId = 4, GenreName = "Rock" });
            GenreDGV.DataSource = GenreBModel.GetGenre();

            #endregion Genre

            #region Artis

            ArtistsBModel.SetArtist(new Artists() { ArtistId = 1, ArtistName = "Yunis" });
            ArtistsBModel.SetArtist(new Artists() { ArtistId = 2, ArtistName = "Samih" });
            ArtistsBModel.SetArtist(new Artists() { ArtistId = 3, ArtistName = "Ibrahim" });
            ArtistsBModel.SetArtist(new Artists() { ArtistId = 4, ArtistName = "Rayan" });
            ArtistsBModel.SetArtist(new Artists() { ArtistId = 5, ArtistName = "Aryan" });

            ArtistDGV.DataSource = ArtistsBModel.GetArtists();

            #endregion Artis

            AlbumsBModel.SetAlbum(new Albums()
            {
                AlbumId = 1,
                AlbumName = "Nature",
                Artists = ArtistsBModel.GetArtists()[0],
                ArtistsId = ArtistsBModel.GetArtists()[0].ArtistId,
                DateReleased = new DateTime(1999, 4, 4),
                Genre = GenreBModel.GetGenre()[0],
                GenreId = GenreBModel.GetGenre()[0].GenreId
            });

            AlbumDGV.DataSource = ShowableAlbum(AlbumsBModel.GetAlbums());
            GetBoxes();
        }

        #region Genre

        private void addGenre_Click(object sender, EventArgs e)
        {
            Genre newGenre = new Genre();
            newGenre.GenreId = Convert.ToInt32(GenreIdTxt.Text);
            newGenre.GenreName = GenreNameTxt.Text;

            GenreBModel.SetGenre(newGenre);
            GenreDGV.DataSource = null;
            GenreDGV.DataSource = GenreBModel.GetGenre();

            newGenreGroup.Enabled = false;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (GenreDGV.SelectedRows.Count > 0)
            {
                GenreBModel.DeleteGenre((int)GenreDGV.CurrentRow.Cells[0].Value);
                GenreDGV.DataSource = null;
                GenreDGV.DataSource = GenreBModel.GetGenre();
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (GenreDGV.SelectedRows.Count > 0)
            {
                GenreUpdateGroup.Enabled = true;
                newGenreGroup.Enabled = false;
            }
        }

        private void UpdateGenreBtn_Click(object sender, EventArgs e)
        {
            Genre oldGenre = new Genre()
            {
                GenreId = (int)GenreDGV.CurrentRow.Cells[0].Value,
                GenreName = (String)GenreDGV.CurrentRow.Cells[1].Value
            };
            Genre newGenre = new Genre()
            {
                GenreId = Convert.ToInt32(UpGenreIdTxt.Text),
                GenreName = UpGenreNameTxt.Text
            };
            GenreBModel.ChangeGenre(oldGenre, newGenre);
            GenreDGV.DataSource = null;
            GenreDGV.DataSource = GenreBModel.GetGenre();

            GenreUpdateGroup.Enabled = false;
        }

        private void AddGenreFuncBtn_Click(object sender, EventArgs e)
        {
            GenreUpdateGroup.Enabled = false;
            newGenreGroup.Enabled = true;
        }

        #endregion Genre

        private void MainWindow_Load(object sender, EventArgs e)
        {
            #region Genre

            GenreUpdateGroup.Enabled = false;
            newGenreGroup.Enabled = false;

            #endregion Genre

            #region Artist

            NewArtistGroup.Enabled = false;
            UpdateArtistGroup.Enabled = false;

            #endregion Artist

            #region Album

            NewAlbumGroup.Enabled = false;
            UpdateAlbumGroup.Enabled = false;

            #endregion Album
        }

        #region Artist

        private void AddFuncArtist_Click(object sender, EventArgs e)
        {
            UpdateArtistGroup.Enabled = false;
            NewArtistGroup.Enabled = true;
        }

        private void AddArtistBtn_Click(object sender, EventArgs e)
        {
            Artists newArtist = new Artists();
            newArtist.ArtistId = Convert.ToInt32(ArtistIdTxt.Text);
            newArtist.ArtistName = ArtistNameTxt.Text;

            ArtistsBModel.SetArtist(newArtist);
            ArtistDGV.DataSource = null;
            ArtistDGV.DataSource = ArtistsBModel.GetArtists();

            NewArtistGroup.Enabled = false;
        }

        private void DeleteFuncArtist_Click(object sender, EventArgs e)
        {
            if (ArtistDGV.SelectedRows.Count > 0)
            {
                ArtistsBModel.DeleteArtist(((int)ArtistDGV.CurrentRow.Cells[0].Value));
                ArtistDGV.DataSource = null;
                ArtistDGV.DataSource = ArtistsBModel.GetArtists();
            }
        }

        private void UpdateFuncArtist_Click(object sender, EventArgs e)
        {
            if (ArtistDGV.SelectedRows.Count > 0)
            {
                NewArtistGroup.Enabled = false;
                UpdateArtistGroup.Enabled = true;
            }
        }

        private void UpdateArtist_Click(object sender, EventArgs e)
        {
            Artists oldArtist = new Artists()
            {
                ArtistId = (int)ArtistDGV.CurrentRow.Cells[0].Value,
                ArtistName = (String)ArtistDGV.CurrentRow.Cells[1].Value
            };
            Artists newArtist = new Artists()
            {
                ArtistId = Convert.ToInt32(UpArtistIdTxt.Text),
                ArtistName = UpArtistNameTxt.Text
            };
            ArtistsBModel.ChangeArtist(oldArtist, newArtist);
            ArtistDGV.DataSource = null;
            ArtistDGV.DataSource = ArtistsBModel.GetArtists();

            UpdateArtistGroup.Enabled = false;
        }

        #endregion Artist

        #region Album

        public List<object> ShowableAlbum(List<Albums> albums)
        {
            List<object> organziedList = new List<object>();

            foreach (Albums album in albums)
            {
                organziedList.Add(new
                {
                    album.AlbumId,
                    album.AlbumName,
                    album.Genre.GenreName,
                    album.Artists.ArtistName,
                    album.DateReleased
                });
            }
            return organziedList;
        }

        public void GetBoxes()
        {
            //Adding
            ArtistsBModel.GetArtists().ForEach(x => ArtistCbx.Items.Add(x.ArtistName));
            GenreBModel.GetGenre().ForEach(x => GenreCbx.Items.Add(x.GenreName));

            //Updating
            ArtistsBModel.GetArtists().ForEach(x => UpArtistCbx.Items.Add(x.ArtistName));
            GenreBModel.GetGenre().ForEach(x => UpGenreCbx.Items.Add(x.GenreName));
        }

        private void AddFuncAlbumBtn_Click(object sender, EventArgs e)
        {
            NewAlbumGroup.Enabled = true;
            UpdateAlbumGroup.Enabled = false;
        }

        private void AddAlbumBtn_Click(object sender, EventArgs e)
        {
            var genre = GenreBModel.GetGenre(GenreCbx.SelectedItem.ToString()).First();
            var artist = ArtistsBModel.GetArtists(ArtistCbx.SelectedItem.ToString()).First();

            Albums newAlbum = new Albums()
            {
                AlbumId = Convert.ToInt32(AlbumIdTxt.Text),
                AlbumName = AlbumNameTxt.Text,
                Artists = artist,
                ArtistsId = artist.ArtistId,
                Genre = genre,
                GenreId = genre.GenreId,
                DateReleased = addDatePicker.Value.Date
            };
            AlbumsBModel.SetAlbum(newAlbum);
            AlbumDGV.DataSource = null;
            AlbumDGV.DataSource = ShowableAlbum(AlbumsBModel.GetAlbums());

            NewAlbumGroup.Enabled = false;
            UpdateAlbumGroup.Enabled = false;
        }

        private void DeleteFuncAlbumBtn_Click(object sender, EventArgs e)
        {
            if (AlbumDGV.SelectedRows.Count > 0)
            {
                AlbumsBModel.DeleteAlbum((int)AlbumDGV.CurrentRow.Cells[0].Value);
                AlbumDGV.DataSource = null;
                AlbumDGV.DataSource = ShowableAlbum(AlbumsBModel.GetAlbums());
            }
        }

        private void UpdateFuncAlbumBtn_Click(object sender, EventArgs e)
        {
            NewAlbumGroup.Enabled = false;
            UpdateAlbumGroup.Enabled = true;
        }

        private void UpdateAlbumBtn_Click(object sender, EventArgs e)
        {
            Albums oldAlbum = new Albums()
            {
                AlbumId = (int)AlbumDGV.CurrentRow.Cells[0].Value,
                AlbumName = (string)AlbumDGV.CurrentRow.Cells[1].Value,
                Genre = GenreBModel.GetGenre((string)AlbumDGV.CurrentRow.Cells[2].Value).First(),
                GenreId = GenreBModel.GetGenre((string)AlbumDGV.CurrentRow.Cells[2].Value).First().GenreId,
                Artists = ArtistsBModel.GetArtists((string)AlbumDGV.CurrentRow.Cells[3].Value).First(),
                ArtistsId = ArtistsBModel.GetArtists((string)AlbumDGV.CurrentRow.Cells[3].Value).First().ArtistId,
                DateReleased = (DateTime)AlbumDGV.CurrentRow.Cells[4].Value
            };
            Albums newAlbum = new Albums()
            {
                AlbumId = Convert.ToInt32(UpAlbumTxt.Text),
                AlbumName = UpAlbumNameTxt.Text,
                Genre = GenreBModel.GetGenre(UpGenreCbx.Text).First(),
                GenreId = GenreBModel.GetGenre(UpGenreCbx.Text.ToString()).First().GenreId,
                Artists = ArtistsBModel.GetArtists(UpArtistCbx.Text.ToString()).First(),
                ArtistsId = ArtistsBModel.GetArtists(UpArtistCbx.Text.ToString()).First().ArtistId,
                DateReleased = UpAlbumPicker.Value.Date
            };
            AlbumsBModel.ChangeAlbum(oldAlbum, newAlbum);
            AlbumDGV.DataSource = null;
            AlbumDGV.DataSource = ShowableAlbum(AlbumsBModel.GetAlbums());

            UpdateAlbumGroup.Enabled = false;
        }

        #endregion Album
    }
}