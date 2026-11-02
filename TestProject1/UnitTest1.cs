using music2026.Interfaces;
using music2026.Models;
using music2026.Services;

namespace TestProject1
{
    public class UnitTest1
    {
        private SongRepo _songsRepo = new SongRepo();

        [Fact]
        public void GetAllSongs_NewRepository_ReturnsEmptyList()
        {
            // Act
            IReadOnlyList<Song> songs = _songsRepo.GetAllSongs();

            // Assert
            Assert.NotNull(songs);
            Assert.Empty(songs);
        }
    }
}
