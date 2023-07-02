using MediaPlayer.Business.src.Service;
using MediaPlayer.Business.src.ServiceInterface;
using MediaPlayer.Domain.src.RepositoryInterface;
using Moq;

namespace MediaPlayer.Tests.src.Business.Tests
{
    public class PlayListServiceTests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddNewFile_Should_Call_Repository_Add_New_File()
        {
            // Arrange
            var mockPlayListRepository = new Mock<IPlayListRepository>();
            var playListService = new PlayListService(mockPlayListRepository.Object);
            var playListId = 111;
            var fileId = 222;
            var userId = 777;

            // Act
            playListService.AddNewFile(playListId, fileId, userId);
        
            // Assert
            mockPlayListRepository.Verify(x => x.AddNewFile(playListId, fileId, userId), Times.Once());
        }

        [Fact]
        public void EmptyList_Should_Call_Repository_Empty_List()
        {
            // Arrange
            var mockPlayListRepository = new Mock<IPlayListRepository>();
            var playListService = new PlayListService(mockPlayListRepository.Object);
            var playListId = 222;
            var userId = 777;

            // Act
            playListService.EmptyList(playListId, userId);
        
            // Assert
            mockPlayListRepository.Verify(x => x.EmptyList(playListId, userId), Times.Once);
        }

        [Fact]
        public void RemoveFile_Should_Call_Repository_Remove_File()
        {
            // Arrange
            var mockPlayListRepository = new Mock<IPlayListRepository>();
            var playListService = new PlayListService(mockPlayListRepository.Object);
            var playListId = 111;
            var fileId = 222;
            var userId = 777;

            // Act
            playListService.RemoveFile(playListId, fileId, userId);

            // Assert
            mockPlayListRepository.Verify(x => x.RemoveFile(playListId, fileId, userId));
        }
    }
}