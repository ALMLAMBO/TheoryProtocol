using TheoryProtocol.Models;

namespace TheoryProtocol.Repositories
{
    public class VoteReposisory : FirestoreRepository<Vote>
    {
        public VoteReposisory(string projectId) : base(projectId, "votes")
        {
        }
    }
}
