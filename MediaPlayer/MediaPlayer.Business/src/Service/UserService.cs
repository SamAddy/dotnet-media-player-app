using MediaPlayer.Business.src.ServiceInterface;
using MediaPlayer.Domain.src.Entity;
using MediaPlayer.Domain.src.RespositoryInterface;

namespace MediaPlayer.Business.src.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public PlayList AddNewList(string name, int userId)
        {
            return _userRepository.AddNewList(name, userId);
        }

        public bool EmptyOneList(int listId, int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayList> GetAllList(int userId)
        {
            throw new NotImplementedException();
        }

        public PlayList GetListById(int listId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAllLists(int userId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveOneList(int listId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}