namespace MediaPlayer.Domain.src.Entity
{
    public abstract class BaseEntity
    {
        private static int _id;

        public int GetId { get; } = _id;

        public BaseEntity()
        {
            _id++;
        }
    }
}