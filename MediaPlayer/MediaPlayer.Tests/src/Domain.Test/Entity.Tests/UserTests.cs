using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Tests.src.Domain.Test.Entity.Tests
{
    public class UserTests
    {
        [Fact]
        public void AddNewList_Should_Add_New_List()
        {
            // Arrange
            var user = User.Instance;
            var playList = new PlayList("My PlayList", 1);

            // Act
            user.AddNewList(playList);

            // Assert
            Assert.Single(user.GetAllLists());
            Assert.Contains(playList, user.GetAllLists());
        }
    }
}