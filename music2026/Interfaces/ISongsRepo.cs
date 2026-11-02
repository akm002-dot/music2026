using music2026.Models;

namespace music2026.Interfaces
{
    public interface ISongsRepo
    {
        IReadOnlyList<Song> GetAllSongs();



    }
}
