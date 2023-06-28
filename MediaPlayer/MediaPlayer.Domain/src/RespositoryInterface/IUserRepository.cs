using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Domain.src.RespositoryInterface
{
    public interface IUserRepository
    {
        PlayList AddNewList(string playlistName, int userId);
        bool RemoveOneList(int playlistId, int userId);
        bool RemoveAllLists(int userId);
        bool EmptyOneList(int playlistId, int userId);
        IEnumerable<User> GetAllList(int userId);
        PlayList GetListById(int listId);
    }
}