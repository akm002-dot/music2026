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
            songs.Add(new() { Id = nextId++, Title = "Song 1", Artist = "Artist 1", PublishYear = 2020, Genre = "Pop" });
        }

        public IEnumerable<Song> GetAllSongs()
        {
            return songs;
        }


    }
}
