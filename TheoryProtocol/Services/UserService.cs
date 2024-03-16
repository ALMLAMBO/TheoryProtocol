using TheoryProtocol.Models;
using TheoryProtocol.Repositories;

namespace TheoryProtocol.Services
{
    public class UserService

    {
        private readonly UserRepository _repository;
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _repository.GetAllAsync();
        }
    }
}
