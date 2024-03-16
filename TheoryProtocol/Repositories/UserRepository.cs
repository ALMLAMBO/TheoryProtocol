using TheoryProtocol.Models;

namespace TheoryProtocol.Repositories
{
    public class UserRepository : FirestoreRepository<User>
    {
        public UserRepository(string projectId) : base(projectId, "users")
        {
        }
    }
}
