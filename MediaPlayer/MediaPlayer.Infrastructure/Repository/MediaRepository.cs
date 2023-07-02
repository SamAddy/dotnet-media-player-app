using MediaPlayer.Domain.src.Entity;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Infrastructure.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly List<MediaFile> _mediaFiles;

        public MediaRepository()
        {
            _mediaFiles = new();
        }

        public T? CreateNewFile<T>(string fileName, string filePath, TimeSpan duration) where T : MediaFile
        {
            T? file;
            if (typeof(T) == typeof(Audio))
            {
                file = new Audio(fileName, filePath, duration) as T;
            }
            else if (typeof(T) == typeof(Video))
            {
                file = new Video(fileName, filePath, duration) as T;
            }
            else
            {
                throw new ArgumentException($"{typeof(T)} is not supported.");
            }
            _mediaFiles.Add(file!);
            return file;
        }

        public bool DeleteFileById(int fileId)
        {
            MediaFile file = GetFileById(fileId);
            if (file != null)
            {
                return _mediaFiles.Remove(file);
            }
            return false;
        }

        public IEnumerable<MediaFile> GetAllFiles()
        {
            return _mediaFiles;
        }

        public MediaFile GetFileById(int fileId)
        {
            return _mediaFiles.FirstOrDefault(file => file.GetId == fileId) ?? throw new ArgumentException("File not found.");
        }

        public void Pause(int fileId)
        {
            MediaFile file = GetFileById(fileId);
            file?.Pause();
        }

        public void Play(int fileId)
        {
            MediaFile file = GetFileById(fileId);
            file?.Play();
        }

        public void Stop(int fileId)
        {
            MediaFile file = GetFileById(fileId);
            file?.Stop();
        }
    }
}