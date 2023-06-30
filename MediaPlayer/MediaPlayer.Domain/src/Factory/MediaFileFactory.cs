using MediaPlayer.Domain.src.Entity;
using MediaPlayer.Domain.src.FactoryInterface;

namespace MediaPlayer.Domain.src.Factory
{
    public class MediaFileFactory : IMediaFileFactory
    {
        public MediaFile CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {
            string fileExtension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(fileExtension))
            {
                throw new ArgumentException("Invalid file type");
            }
            return fileExtension.ToLower() switch
            {
                ".mp3" or ".wav" => new Audio(fileName, filePath, duration),
                ".mp4" or ".avi" => new Video(fileName, filePath, duration),
                _ => throw new NotSupportedException("File type not supported."),
            };
        }
    }
}