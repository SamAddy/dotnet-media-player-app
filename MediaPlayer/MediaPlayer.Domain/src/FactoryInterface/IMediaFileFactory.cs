using MediaPlayer.Domain.src.Entity;

namespace MediaPlayer.Domain.src.FactoryInterface
{
    public interface IMediaFileFactory
    {
        MediaFile CreateNewFile(string fileName, string filePath, TimeSpan duration);
    }
}