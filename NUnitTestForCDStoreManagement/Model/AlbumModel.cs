using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestForCDStoreManagement.Model
{
    public class AlbumModel
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int ReleaseYear { get; set; }
        public string Author { get; set; }
        public string AlbumGenre { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }

    public class AlbumService
    {
        private static List<AlbumModel> albums = new List<AlbumModel>()
        {
            new AlbumModel()
            {
                AlbumId = 1,
                AlbumName = "The Greatest Hits",
                ReleaseYear = 2005,
                Author = "John Smith",
                AlbumGenre = "Pop",
                Price = 9.99,
                Quantity = 50,
                Description = "A compilation of the artist's best songs from their career."
            },
            new AlbumModel()
            {
                AlbumId = 2,
                AlbumName = "Revival",
                ReleaseYear = 2017,
                Author = "Eminem",
                AlbumGenre = "Hip Hop",
                Price = 12.99,
                Quantity = 25,
                Description = "The ninth studio album by Eminem, featuring guest artists and introspective lyrics."
            },
            new AlbumModel()
            {
                AlbumId = 3,
                AlbumName = "Back in Black",
                ReleaseYear = 1980,
                Author = "AC/DC",
                AlbumGenre = "Rock",
                Price =  11.99,
                Quantity = 20,
                Description = "The seventh studio album by AC/DC, known for its iconic guitar riffs and hard rock sound."
            }

        };

        public static List<AlbumModel> GetAlbums()
        {
            return albums.ToList();
        }

        public static List<AlbumModel> SearchAlbums(string searchValue, List<AlbumModel> albums)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                return new List<AlbumModel>();
            }
            return albums
                .Where(a => a.Author.ToLower().Contains(searchValue.ToLower())
                         || a.AlbumName.ToLower().Contains(searchValue.ToLower())
                         || a.AlbumGenre.ToLower().Contains(searchValue.ToLower()))
                .ToList();
        }
    }
}
