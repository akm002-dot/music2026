using music2026.Interfaces;
using music2026.Models;

namespace music2026.Services
{
    public class SongRepo : ISongsRepo
    {
        private List<Song> songs = new List<Song>();

        private int nextId = 1;

        public SongRepo()
        {
            AddSong(new Song {Title = "Song 1", Artist = "Artist 1", PublishYear = 2020, Genre = "Pop" });
            AddSong(new Song { Title = "Song 2", Artist = "Artist 2", PublishYear = 2021, Genre = "Rock" });
            AddSong(new Song { Title = "Song 3", Artist = "Artist 3", PublishYear = 2022, Genre = "Jazz" });
            AddSong(new Song { Title = "12345", Artist = "Artist 4", PublishYear = 2023, Genre = "Hip Hop" });
        }


        public IEnumerable<Song> GetAllSongs()
        {
            return songs;
        }

        public Song AddSong(Song s)
        {
            s.Id = nextId++;
            songs.Add(s);
            return s;
        }

        public IEnumerable<Song> SearchSongs(string property, string text)
        {

            

            if (property == "Title")
            {
                return songs.Where(s => s.Title != null && s.Title.Contains(text, StringComparison.OrdinalIgnoreCase));
            }
            else if (property == "Artist")
            {
                return songs.Where(s => s.Artist != null && s.Artist.Contains(text, StringComparison.OrdinalIgnoreCase));
            }
            else if (property == "PublishYear")
            {
                return songs.Where(s => s.PublishYear.ToString() == text);
            }
            else if (property == "Genre")
            {
                return songs.Where(s => s.Genre != null && s.Genre.Contains(text, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                return new List<Song>();
            }
        }
        public Song DeleteSong(int id)
        {
            Song? song = songs.FirstOrDefault(s => s.Id == id);
            if (song != null)
            {
                songs.Remove(song);
            }
            return song;
        }

        public int CountSongs()
        {
            return songs.Count;
        }
    }
}
