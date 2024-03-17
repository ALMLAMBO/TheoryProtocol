using Google.Cloud.Firestore;
using TheoryProtocol.Models;

namespace TheoryProtocol.Repositories
{
    public class ConnectionRepository : FirestoreRepository<Connection>
    {
        private string _idDocumentName = "connectionsId";
        public ConnectionRepository(string projectId) : base(projectId, "connections")
        {
        }

        public async void AddConnection(Fact from, Fact to)
        {
            int prevId = await GetIdAsync(_idDocumentName);
            Connection conn = new Connection
            {
                CanvasId = from.CanvasId,
                StartPointId = from.Id,
                EndPointId = to.Id,
                Id = prevId + 1
            };
            await UpdateIdAsync(_idDocumentName);
            await AddAsync(conn);
        }
    }
}
