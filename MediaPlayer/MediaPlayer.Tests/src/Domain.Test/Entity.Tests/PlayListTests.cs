using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Tests.src.Domain.Test.Entity.Tests
{
    public class PlayListTests
    {
        [Fact]
        public void PlayList_Constructor_Should_Create_Instance_With_Correct_Properties()
        {
            // Arrange
            string listName = "My Playlist_1";
            int userId = 1;

            // Act 
            var playList = new PlayList(listName, userId);

            // Assert
            Assert.Equal(userId, playList.UserId);
            Assert.Equal(listName, playList.ListName);
        }

        [Fact]
        public void AddNewFile_Should_Add_New_File_When_Id_Matches()
        {
            // Arrange
            var playList = new PlayList("My Music Playlist", 1);
            var audioFile = new Audio("audio.mp3", "music/audio.mp3", TimeSpan.FromSeconds(90), 1.5);

            // Act
            playList.AddNewFile(audioFile, 1);

            // Assert
            Assert.Contains(audioFile, playList.Files);
            Assert.Equal(audioFile, playList.GetFileByName(audioFile.FileName));
        }

        [Fact]
        public void AddNewFile_Should_Not_Add_New_File_When_Id_Does_Not_Match()
        {
            // Arrange
            var playList = new PlayList("My Music Playlist", 1);
            var audioFile = new Audio("audio.mp3", "music/audio.mp3", TimeSpan.FromSeconds(90), 1.5);

            // Act
            playList.AddNewFile(audioFile, 2);

            // Assert
            Assert.DoesNotContain(audioFile, playList.Files);
        }

        [Fact]
        public void RemoveFile_Should_Remove_File_From_List_When_Id_Matches()
        {
            // Arrange
            var playList = new PlayList("My Video Playlist", 1);
            var videoFile = new Video("video.mp4", "videos/video.mp4", TimeSpan.FromSeconds(5400));

            // Act
            playList.AddNewFile(videoFile, 1);
            playList.RemoveFile(videoFile, 1);

            // Assert
            Assert.DoesNotContain(videoFile, playList.Files);
        }

        [Fact]
        public void RemoveFile_Should_Not_Remove_File_When_Id_Does_Not_Match()
        {
            // Arrange
            var playList = new PlayList("My Video Playlist", 1);
            var videoFile = new Video("video.mp4", "videos/video.mp4", TimeSpan.FromSeconds(5400));

            // Act
            playList.AddNewFile(videoFile, 1);
            playList.RemoveFile(videoFile, 2);

            // Assert
            Assert.Contains(videoFile, playList.Files);
        }

        [Fact]
        public void EmptyList_Should_Empty_List_When_Id_Matches()
        {
            // Arrange
            var playList = new PlayList("My Video Playlist", 1);
            var videoFile = new Video("video.mp4", "videos/video.mp4", TimeSpan.FromSeconds(5400));
            var videoFile2 = new Video("video2.mp4", "videos/video2.mp4", TimeSpan.FromSeconds(5000));

            // Act
            playList.AddNewFile(videoFile, 1);
            playList.AddNewFile(videoFile2, 1);
            playList.EmptyList(1);

            // Assert
            Assert.Empty(playList.Files);
        }

        [Fact]
        public void EmptyList_Should_Not_Empty_List_When_Id_Does_Not_Match()
        {
            // Arrange
            var playList = new PlayList("My Video Playlist", 1);
            var videoFile = new Video("video.mp4", "videos/video.mp4", TimeSpan.FromSeconds(5400));
            var videoFile2 = new Video("video2.mp4", "videos/video2.mp4", TimeSpan.FromSeconds(5000));

            // Act
            playList.AddNewFile(videoFile, 1);
            playList.AddNewFile(videoFile2, 1);
            playList.EmptyList(2);

            // Assert
            Assert.NotEmpty(playList.Files);
            Assert.Equal(2, playList.Files.Count);
        }

        [Theory]
        [MemberData(nameof(TestAddNewFileData))]
        public void AddNewFile_Should_Add_New_File(string fileName, string filePath, TimeSpan duration, string playListName, int userId)
        {
            // Arrange
            var playList = new PlayList(playListName, userId);
            var audioFile = new Audio(fileName, filePath, duration);

            // Act
            playList.AddNewFile(audioFile, userId);

            // Assert
            Assert.Contains(audioFile, playList.Files);
        }

        public static IEnumerable<object[]> TestAddNewFileData
        {
            get
            {
                yield return new object[] { "audio.mp3", "music/audio.mp3", TimeSpan.FromSeconds(90), "My Playlist", 1 };
                yield return new object[] { "audio2.mp3", "music/audio2.mp3", TimeSpan.FromSeconds(100), "My Playlist", 2 };
                yield return new object[] { "audio3.mp3", "music/audio3.mp3", TimeSpan.FromSeconds(101), "My Playlist", 1 };
            }
        }
    }
}