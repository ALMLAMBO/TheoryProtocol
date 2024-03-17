using Google.Cloud.Firestore;
using TheoryProtocol.Models;

namespace TheoryProtocol.Repositories
{
    public class ConnectionRepository : FirestoreRepository<Connection>
    {
        public ConnectionRepository(string projectId) : base(projectId, "connections")
        {
        }

        public async void AddConnection(Fact from, Fact to)
        {
            Connection conn = new Connection
            {
                CanvasId = from.CanvasId,
                StartPointId = from.Id,
                EndPointId = to.Id,
                //TODO: Define this dynamically
                Id = 1
            };
            await AddAsync(conn);
        }
    }
}
