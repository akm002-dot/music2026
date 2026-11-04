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
            IEnumerable<Song> songs = _songsRepo.GetAllSongs();

            // Assert
            Assert.NotNull(songs);
        }

        [Fact]
        public void NullOrEmptyPropertyOrText_ReturnsEmptyList()
        {
            // Arrange
            string? property = null;
            string text = null;
            // Act
            IEnumerable<Song> result = _songsRepo.SearchSongs(property, text);
            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SearchSongs_Title_ValidPropertyAndText_ReturnsMatchingSongs()
        {
            _songsRepo.AddSong(new Song { Title = "wwwddwdw", Artist = "Artist 1", PublishYear = 2020, Genre = "Pop" });
            // Arrange
            string property = "Title";
            string text = "wwwddwdw";
            // Act
            IEnumerable<Song> result = _songsRepo.SearchSongs(property, text);
            // Assert
            Assert.Single(result);
            Assert.Equal("wwwddwdw", result.First().Title);
        }
        [Fact]
        public void SearchSongs_TitleProperty_ReturnsEmptyList()
        {
            //Arrange
            _songsRepo.AddSong(new Song
            {
                Title = null,
                Artist = null,
                PublishYear = 1928,
                Genre = null
            });
            //ACT
            IEnumerable<Song> result = _songsRepo.SearchSongs("Title", "SomeText");
            IEnumerable<Song> result2 = _songsRepo.SearchSongs("Artist", "SomeText");
            IEnumerable<Song> result3 = _songsRepo.SearchSongs("Genre", "SomeText");
            //Assert
            Assert.Empty(result);
            Assert.Empty(result2);
            Assert.Empty(result3);
        }
        [Fact]
        public void SearchSongs_InvalidProperty_ReturnsEmptyList()
        {
            // Arrange
            string property = "InvalidProperty";
            string text = "SomeText";
            // Act
            IEnumerable<Song> result = _songsRepo.SearchSongs(property, text);
            // Assert
            Assert.Empty(result);
        }
        [Fact]
        public void SearchSongs_GenreProperty_ReturnsMatchingSongs()
        {
            _songsRepo.AddSong(new Song { Title = "Test Song", Artist = "Test Artist", PublishYear = 2023, Genre = "Test12345w" });
            // Arrange
            string property = "Genre";
            string text = "TEST12345W";
            // Act
            IEnumerable<Song> result = _songsRepo.SearchSongs(property, text);
            // Assert
            Assert.Single(result);
            Assert.Equal("Test12345w", result.First().Genre);
        }
        [Fact]
        public void SearchSongs_PublishYearProperty_ReturnsMatchingSongs()
        {
            _songsRepo.AddSong(new Song { Title = "Test Song", Artist = "Test Artist", PublishYear = 99999999, Genre = "Test Genre" });
            // Arrange
            string property = "PublishYear";
            string text = "99999999";
            // Act
            IEnumerable<Song> result = _songsRepo.SearchSongs(property, text);
            // Assert
            Assert.Single(result);
            Assert.Equal(99999999, result.First().PublishYear);
        }
        [Fact]
        public void SearchSongs_ArtistProperty_ReturnsMatchingSongs()
        {
            _songsRepo.AddSong(new Song { Title = "Test Song", Artist = "Test Artist 12345", PublishYear = 2023, Genre = "Test Genre" });
            // Arrange
            string property = "Artist";
            string text = "Test Artist 12345";
            // Act
            IEnumerable<Song> result = _songsRepo.SearchSongs(property, text);
            // Assert
            Assert.Single(result);
            Assert.Equal("Test Artist 12345", result.First().Artist);
        }

        [Fact]
        public void DeleteSongBeforeAfterCountCheck()
        {
            // Arrange
            Song songToDelete = _songsRepo.AddSong(new Song { Title = "Song to Delete", Artist = "Artist", PublishYear = 2023, Genre = "Genre" });
            int initialCount = _songsRepo.CountSongs();
            // Act
            Song deletedSong = _songsRepo.DeleteSong(songToDelete.Id);
            int finalCount = _songsRepo.CountSongs();
            // Assert
            Assert.NotNull(deletedSong);
            Assert.Equal(initialCount - 1, finalCount);
        }
        [Fact]
        public void DeleteSongIsNull()
        {
            // Arrange
            int nonExistentId = -1;
            // Act
            Song deletedSong = _songsRepo.DeleteSong(nonExistentId);
            // Assert
            Assert.Null(deletedSong);
        }

        [Fact] 
        public void GetById_ExistingSong_ReturnsSong()
        {
            // Arrange

            // Act
            Song retrievedSong = _songsRepo.GetById(1);
            // Assert
            Assert.NotNull(retrievedSong);
            Assert.Equal(1, retrievedSong.Id);
        }

        [Fact]
        public void GetById_NonExistentSong_ThrowsKeyNotFoundException()
        {
            // Arrange
            int nonExistentId = -1;
            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _songsRepo.GetById(nonExistentId));
        }
        [Fact]
        public void GetById_NullId_ThrowsKeyNotFoundException()
        {
            // Arrange
            int nullId = 0; // Assuming 0 is not a valid ID in your repository
            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _songsRepo.GetById(nullId));
        }
    }

}

