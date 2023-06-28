namespace MediaPlayer.Domain.src.Entity
{
    public class Audio : MediaFile
    {
        public Audio(string fileName, string filePath, TimeSpan duration, double speed = 1) : base(fileName, filePath, duration, speed)
        {
        }
    }
}