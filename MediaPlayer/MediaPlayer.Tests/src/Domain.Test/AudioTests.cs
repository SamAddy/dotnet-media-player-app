using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Tests.src.Domain.Test
{
    public class AudioTest
    {
        [Fact]
        public void Audio_Constructor_Should_Create_Instance_With_Correct_Properties()
        {
            // Arrange
            string fileName = "audio.mp3";
            string filePath = "music/audio.mp3";
            TimeSpan duration = TimeSpan.FromSeconds(180);
            double speed = 1.5;

            // Act
            var audio = new Audio(fileName, filePath, duration, speed);

            // Assert
            Assert.Equal(fileName, audio.FileName);
            Assert.Equal(filePath, audio.FilePath);
            Assert.Equal(duration, audio.Duration);
            Assert.Equal(speed, audio.Speed);
        }
    }
}