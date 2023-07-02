using MediaPlayer.Domain.src.Entity;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Infrastructure.Repository
{
    public class PlayListRepository : IPlayListRepository
    {
        private readonly Dictionary<int, List<int>> _playListDictionary;
        private readonly Dictionary<int, HashSet<int>> _userPlayListDictionary;
        private readonly IMediaRepository _mediaRepository;


        public PlayListRepository(IMediaRepository mediaRepository)
        {
            _playListDictionary = new();
            _userPlayListDictionary = new();
            _mediaRepository = mediaRepository;
        }

        public MediaFile AddNewFile(int playListId, int fileId, int userId)
        {
            if (!_userPlayListDictionary.TryGetValue(userId, out var userPlayLists) || !userPlayLists.Contains(playListId))
            {
                throw new UnauthorizedAccessException("User does not have access to the playlist.");
            }
            if (!_playListDictionary.TryGetValue(playListId, out var playList))
            {
                playList = new List<int>();
                _playListDictionary.Add(playListId, playList);
            }
            MediaFile mediaFile = _mediaRepository.GetFileById(fileId);
            return mediaFile;
        }

        public bool EmptyList(int playListId, int userId)
        {
            if (!_userPlayListDictionary.TryGetValue(userId, out var userPlayLists) || !userPlayLists.Contains(playListId))
            {
                throw new UnauthorizedAccessException("User does not have access to the playlist.");
            }
            if (_playListDictionary.TryGetValue(playListId, out var playList))
            {
                playList.Clear();
                return true;
            }
            return false;
        }

        public bool RemoveFile(int playListId, int fileId, int userId)
        {
            if (!_userPlayListDictionary.TryGetValue(userId, out var userPlayLists) || !userPlayLists.Contains(playListId))
            {
                throw new UnauthorizedAccessException("User does not have access to the playlist.");
            }
            if (_playListDictionary.TryGetValue(playListId, out var playList))
            {
                return playList.Remove(fileId);
            }
            return false;
        }
    }
}