using MediaPlayer.Business.src.ServiceInterface;
using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Application.src
{
    public class MediaController
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public T CreateNewFile<T>(string fileName, string filePath, TimeSpan duration) where T : MediaFile
        {
           return  _mediaService.CreateNewFile<T>(fileName, filePath, duration);
        }

        public bool DeleteFileById(int id)
        {
            return _mediaService.DeleteFileById(id);
        }

        public IEnumerable<MediaFile> GetAllFiles()
        {
            return _mediaService.GetAllFiles();
        }

        public MediaFile GetFileById(int id)
        {
            return _mediaService.GetFileById(id);
        }
    }
}