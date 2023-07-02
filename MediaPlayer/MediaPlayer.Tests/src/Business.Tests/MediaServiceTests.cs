using MediaPlayer.Business.src.Service;
using MediaPlayer.Domain.src.Entity;
using MediaPlayer.Domain.src.RepositoryInterface;
using MediaPlayer.Tests.src.Domain.Test.Entity.Tests;
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

        [Fact] 
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

        [Fact]
        public void DeleteFileById_Should_Call_Repository_DeleteFileById()
        {
            // Arrange 
            var mockMediaRepository = new Mock<IMediaRepository>();
            var mediaService = new MediaService(mockMediaRepository.Object);
            var fileId = 1;

            // Act
            mediaService.DeleteFileById(fileId);

            // Assert
            mockMediaRepository.Verify(r => r.DeleteFileById(fileId), Times.Once);
        }

        [Fact]
        public void GetAllFiles_Should_Call_Repository_GetAllFiles()
        {
            // Arrange
            var mockMediaRepository = new Mock<IMediaRepository>();
            var mediaService = new MediaService(mockMediaRepository.Object);
            var files = new List<MediaFile> { new Video("video.mp4", "videos/video.mp4", TimeSpan.FromSeconds(5000)) };
            mockMediaRepository.Setup(r => r.GetAllFiles()).Returns(files);
        
            // Act
            var result = mediaService.GetAllFiles();
        
            // Assert
            Assert.Equal(files, result);
            mockMediaRepository.Verify(r => r.GetAllFiles(), Times.Once);
        }

        [Fact]
        public void GetFileById_Should_Call_Repository_GetFileById()
        {
            // Arrange
            var mockMediaRepository = new Mock<IMediaRepository>();
            var mediaService = new MediaService(mockMediaRepository.Object);
            var fileId = 1;
            var file = new Video("video.mp4", "videos/video.mp4", TimeSpan.FromSeconds(5000));
            mockMediaRepository.Setup(r => r.GetFileById(fileId)).Returns(file);
        
            // Act
            var result = mediaService.GetFileById(fileId);
        
            // Assert
            Assert.Equal(file, result);
            mockMediaRepository.Verify(r => r.GetFileById(fileId), Times.Once);
        }
    }
}