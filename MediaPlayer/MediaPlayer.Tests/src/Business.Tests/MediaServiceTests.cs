using MediaPlayer.Business.src.Service;
using MediaPlayer.Domain.src.Entity;
using MediaPlayer.Domain.src.RespositoryInterface;
using Moq;

namespace MediaPlayer.Tests.src.Business.Tests
{
    public class MediaServiceTests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        public void CreateNewFile_Should_Call_Repository_CreateNewFile()
        {
            // Arrange
            var mockMediaRepository = new Mock<IMediaRepository>();
            var mediaService = new MediaService(mockMediaRepository.Object);
            var fileName = "audio.mp3";
            var filePath = "music/audio.mp3";
            var duration = TimeSpan.FromSeconds(50);

            // Act
            mediaService.CreateNewFile<Audio>(fileName, filePath, duration);

            // Assert
            mockMediaRepository.Verify(r => r.CreateNewFile<Audio>(fileName, filePath, duration), Times.Once);
        }

        public void DeleteFileById_Should_Call_Repository_DeleteFileById()
        {
            // Arrange 
            var mockMediaRepository = new Mock<IMediaRepository>();
            var mediaService = new MediaService(mockMediaRepository.Object);
            var fileId = 1;

            // Act
            // mediaService.DeleteFileById<Audio>(fileId);

            // Assert
            mockMediaRepository.Verify(r => r.DeleteFileById(fileId), Times.Once);
        }
    }
}