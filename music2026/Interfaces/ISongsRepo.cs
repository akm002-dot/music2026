using music2026.Models;
using music2026.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace music2026.Interfaces
{
    public interface ISongsRepo
    {
        IEnumerable<Song> GetAllSongs();
        Song AddSong(Song s);
        IEnumerable<Song> SearchSongs(string property, string text);

    }
}
