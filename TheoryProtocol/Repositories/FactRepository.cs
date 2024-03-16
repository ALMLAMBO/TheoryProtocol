using TheoryProtocol.Models;

namespace TheoryProtocol.Repositories
{
    public class FactRepository : FirestoreRepository<Fact>
    {
        public FactRepository(string projectId) : base(projectId, "facts")
        {
        }
    }
}
