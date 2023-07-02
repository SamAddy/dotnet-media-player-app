using MediaPlayer.Business.src.ServiceInterface;
using MediaPlayer.Domain.src.Entity;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Business.src.Service
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository; 
        }
        public T CreateNewFile<T>(string fileName, string filePath, TimeSpan duration) where T : MediaFile
        {
            return _mediaRepository.CreateNewFile<T>(fileName, filePath, duration)!;
        }

        public bool DeleteFileById(int id)
        {
            return _mediaRepository.DeleteFileById(id);
        }

        public IEnumerable<MediaFile> GetAllFiles()
        {
            return _mediaRepository.GetAllFiles();
        }

        public MediaFile GetFileById(int id)
        {
            return _mediaRepository.GetFileById(id);
        }
    }
}