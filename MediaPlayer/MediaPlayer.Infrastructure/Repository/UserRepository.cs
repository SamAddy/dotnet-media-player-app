using MediaPlayer.Domain.src.Entity;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Dictionary<int, List<PlayList>> _userPlayLists;

        public UserRepository()
        {
            _userPlayLists = new();
        }
        public PlayList AddNewList(string playlistName, int userId)
        {
            if (!_userPlayLists.ContainsKey(userId))
            {
                _userPlayLists[userId] = new List<PlayList>();
            }
            var playList = new PlayList(playlistName, userId);
            _userPlayLists[userId].Add(playList);
            return playList;
        }

        public bool EmptyOneList(int playlistId, int userId)
        {
            if (_userPlayLists.TryGetValue(userId, out var playLists))
            {
                var playListToEmtpy = playLists.FirstOrDefault(playList => playList.GetId == playlistId);
                if (playListToEmtpy != null)
                {
                    playListToEmtpy.EmptyList(userId);
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<PlayList> GetAllList(int userId)
        {
            if (_userPlayLists.TryGetValue(userId, out var playLists))
            {
                // return playLists.Select(playList => new User(userId, playList));
            }
            return Enumerable.Empty<PlayList>();
        }

        public PlayList GetListById(int listId)
        {
            var allPlayLists = _userPlayLists.Values.SelectMany(playLists => playLists);
            return allPlayLists.FirstOrDefault(playlist => playlist.GetId == listId) ?? throw new ArgumentException("Playlist Id was not found.");
        }

        public bool RemoveAllLists(int userId)
        {
            return _userPlayLists.Remove(userId);
        }

        public bool RemoveOneList(int playListId, int userId)
        {
            if (_userPlayLists.TryGetValue(userId, out var playLists))
            {
                var playListToRemove = playLists.FirstOrDefault(playList => playList.GetId == playListId);
                if (playListToRemove != null)
                {
                    playLists.Remove(playListToRemove);
                    return true;
                }
            }
            return false;
        }
    }
}