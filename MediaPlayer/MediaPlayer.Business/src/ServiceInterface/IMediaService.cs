using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Business.src.ServiceInterface
{
    public interface IMediaService
    {
        T CreateNewFile<T>(string fileName, string filePath, TimeSpan duration) where T : MediaFile;
        bool DeleteFileById(int id);
        IEnumerable<MediaFile> GetAllFiles();
        MediaFile GetFileById(int id);
    }
}