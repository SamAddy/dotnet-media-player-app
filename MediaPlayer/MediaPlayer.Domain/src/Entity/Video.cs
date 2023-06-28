namespace MediaPlayer.Domain.src.Entity
{
    public class Video : MediaFile
    {
        public Video(string fileName, string filePath, TimeSpan duration, double speed = 1) : base(fileName, filePath, duration, speed)
        {
        }
    }
}