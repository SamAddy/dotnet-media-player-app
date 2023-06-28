using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Business.src.ServiceInterface
{
    public interface IPlayListService
    {
        MediaFile AddNewFile(int playListId, int fileId, int userId);
        bool RemoveFile(int playListId, int fileId, int userId);
        bool EmptyList(int playListId, int userId);
    }
}