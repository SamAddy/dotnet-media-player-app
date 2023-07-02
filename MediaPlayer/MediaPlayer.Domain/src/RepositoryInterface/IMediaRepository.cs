using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Domain.src.RepositoryInterface
{
    public interface IMediaRepository
    {
        void Play(int fileId);
        void Pause(int fileId);
        void Stop(int fileId);
        T? CreateNewFile<T>(string fileName, string filePath, TimeSpan duration) where T : MediaFile;
        bool DeleteFileById(int fileId);
        IEnumerable<MediaFile> GetAllFiles();
        MediaFile GetFileById(int fileId);
    }
}