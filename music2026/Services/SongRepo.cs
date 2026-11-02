using music2026.Models;

namespace music2026.Services
{
    public class SongRepo
    {
        private List<Song> songs = new List<Song>();

        private int nextId = 1;


        public IReadOnlyList<Song> GetAllSongs()
        {
            return songs.AsReadOnly();
        }

    }
}
