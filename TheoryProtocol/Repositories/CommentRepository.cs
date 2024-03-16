using TheoryProtocol.Models;

namespace TheoryProtocol.Repositories
{
    public class CommentRepository : FirestoreRepository<Comment>
    {
        public CommentRepository(string projectId) : base(projectId, "comments")
        {
        }
    }
}
