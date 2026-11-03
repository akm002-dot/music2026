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
        public void SearchSongs_Title_TextIsNullOrEmpty_ReturnsEmptyList()
        {
            _songsRepo.AddSong(new Song { Title = null, Artist = "Artist 1", PublishYear = 2020, Genre = "Pop" });
            // Arrange
            string property = "Title";
            string text = null;
            // Act
            IEnumerable<Song> result = _songsRepo.SearchSongs(property, text);
            // Assert
            Assert.Empty(result);
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
        public void SearchByTitle_ReturnsOnlySongsWithMatchingNonNullTitle()
        {
            var songs = new List<Song>
        {
            new() { Title = "Bohemian Rhapsody" },
            new() { Title = "Another Song" },
            new() { Title = null }
        };

            var result = _songsRepo.SearchSongs("Title", "bohemian").ToList();

            Assert.Single(result);
            Assert.Equal("Bohemian Rhapsody", result[0].Title);
        }

        [Fact]
        public void SearchByTitle_IsCaseInsensitive()
        {
            var songs = new List<Song>
        {
            new() { Title = "Bohemian Rhapsody" }
        };

            var result = _songsRepo.SearchSongs("Title", "BOHEMIAN").ToList();

            Assert.Single(result);
        }

        [Fact]
        public void SearchByTitle_DoesNotReturnSongWithNullTitle()
        {
            
        
            _songsRepo.AddSong(new Song { Title = null, Artist = null, PublishYear = 0, Genre = null });
        

            var result = _songsRepo.SearchSongs("Title", null);
            var result2 = _songsRepo.SearchSongs("Artist", null);
            var result3 = _songsRepo.SearchSongs("Genre", null);

            Assert.Empty(result);
            Assert.Empty(result2);
            Assert.Empty(result3);
        }
    }



}

