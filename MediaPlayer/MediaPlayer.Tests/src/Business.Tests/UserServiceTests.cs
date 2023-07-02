using Moq;
using MediaPlayer.Domain.src.RepositoryInterface;
using MediaPlayer.Business.src.Service;
using MediaPlayer.Domain.src.Entity;
using System.ComponentModel;

namespace MediaPlayer.Tests.src.Business.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddNewList_Should_Call_Repository_Add_New_List()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);
            var name = "PlayList 1";
            var userId = 777;
        
            // Act
            userService.AddNewList(name, userId);
        
            // Assert
            mockUserRepository.Verify(x => x.AddNewList(name, userId), Times.Once);
        }

        [Fact]
        public void EmptyOneList_Should_Call_Repository_EmptyOneList()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);
            var listId = 1;
            var userId = 777;

            // Act
            userService.EmptyOneList(listId, userId);

            // Arrange
            mockUserRepository.Verify(x => x.EmptyOneList(listId, userId), Times.Once);
        }

        [Fact]
        public void GetAllList_Should_Call_Repository_GetAllList()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);
            var userId = 777;
            var name1 = "PlayList 1";
            var name2 = "PlayList 2";
            var lists = new List<PlayList> { new PlayList(name1, userId), new PlayList(name2, userId)  };
            mockUserRepository.Setup(x => x.GetAllList(userId)).Returns(lists);

            // Act
            var result = userService.GetAllList(userId);
        
            // Assert
            Assert.Equal(lists, result);
            mockUserRepository.Verify(x => x.GetAllList(userId), Times.Once);
        }

        [Fact]
        public void GetListById_Should_Call_Repository_GetListById()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);
            var listId = 1;
            var userId = 777;
            var listName = "PlayList";
            var playlist = new PlayList(listName, userId);
            mockUserRepository.Setup(x => x.GetListById(listId)).Returns(playlist);

            // Act
            var result = userService.GetListById(listId);

            // Assert
            Assert.Equal(playlist, result);
            mockUserRepository.Verify(r => r.GetListById(listId), Times.Once);
        }

        [Fact]
        public void RemoveAllLists_Should_Call_Repository_RemoveAllLists()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);
            var userId = 777;

            // Act
            userService.RemoveAllLists(userId);
        
            // Assert
            mockUserRepository.Verify(x => x.RemoveAllLists(userId), Times.Once);
        }

        [Fact]
        public void RemoveOneList_Should_Call_Repository_RemoveOneList()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);
            var listId = 1;
            var userId = 777;
            

            // Act
            userService.RemoveOneList(listId, userId);
        
            // Assert
            mockUserRepository.Verify(x => x.RemoveOneList(listId, userId), Times.Once);
        }
    }
}