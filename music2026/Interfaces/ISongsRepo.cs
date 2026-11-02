using music2026.Models;
using music2026.Services;

namespace music2026.Interfaces
{
    public interface ISongsRepo
    {
        IReadOnlyList<Song> GetAllSongs();

        

    }
}
