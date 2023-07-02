using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Domain.src.RepositoryInterface
{
    public interface IPlayListRepository
    {
        MediaFile AddNewFile(int playListId, int fileId, int userId);
        bool RemoveFile(int playListId, int fileId, int userId);
        bool EmptyList(int playListId, int userId);
    }
}