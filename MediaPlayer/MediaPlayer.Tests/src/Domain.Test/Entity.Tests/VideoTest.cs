using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Tests.src.Domain.Test.Entity.Tests
{
    public class VideoTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void Audio_Constructor_Should_Create_Instance_With_Correct_Properties()
        {
            // Arrange
            string fileName = "video.mp4";
            string filePath = "videos/video.mp4";
            TimeSpan duration = TimeSpan.FromSeconds(5400);
            double speed = 1;

            // Act
            var video = new Video(fileName, filePath, duration, speed);
            
            // Assert
            Assert.Equal(fileName, video.FileName);
            Assert.Equal(filePath, video.FilePath);
            Assert.Equal(duration, video.Duration);
            Assert.Equal(speed, video.Speed);
        }
    }
}