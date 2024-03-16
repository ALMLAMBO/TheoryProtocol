using TheoryProtocol.Models;

namespace TheoryProtocol.Repositories
{
    public class ConnectionRepository : FirestoreRepository<Connection>
    {
        public ConnectionRepository(string projectId) : base(projectId, "connections")
        {
        }
    }
}
