namespace P02_MusicalAlbums
{
    using P02_MusicalAlbums.Models;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            var serializer = new XmlSerializer(typeof(AlbumDto[]), new XmlRootAttribute("albums"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../catalog.xml";

            var students = GetAlbums();

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, students, namespaces);
            }
        }

        private static AlbumDto[] GetAlbums()
        {
            var firstAlbum = new AlbumDto
            {
                Name = "The King of Limbs",
                Artist = "RadioHead",
                Producer = "Uncle Sam",
                Price = 34.00m,
                Year = 2002,
                Songs = new SongDto[5]
                {
                    new SongDto{ Title = "Bloom", Duration = "3:52"},
                    new SongDto{ Title = "Feral", Duration = "4:41"},
                    new SongDto{ Title = "Codex", Duration = "5:01"},
                    new SongDto{ Title = "Give up the ghost", Duration = "4:22"},
                    new SongDto{ Title = "Airbag", Duration = "4:33"},
                }
            };

            var secondAlbum = new AlbumDto
            {
                Name = "Third",
                Artist = "Portishead",
                Producer = "Portishead",
                Price = 60.00m,
                Year = 2009,
                Songs = new SongDto[5]
                {
                    new SongDto{ Title = "Hunter", Duration = "3:52"},
                    new SongDto{ Title = "The Rip", Duration = "4:41"},
                    new SongDto{ Title = "Roads", Duration = "5:01"},
                    new SongDto{ Title = "Small", Duration = "4:22"},
                    new SongDto{ Title = "Machine Gun", Duration = "4:33"},
                }
            };

            return new AlbumDto[] { firstAlbum, secondAlbum };
        }
    }
}
