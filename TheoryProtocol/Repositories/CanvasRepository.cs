using TheoryProtocol.Models;

namespace TheoryProtocol.Repositories
{
    public class CanvasRepository : FirestoreRepository<Canvas>
    {
        public CanvasRepository(string projectId, string collectionName) : base(projectId, collectionName)
        {
        }
    }
}
