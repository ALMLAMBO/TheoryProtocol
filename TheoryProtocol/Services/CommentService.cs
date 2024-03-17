using TheoryProtocol.Models;
using TheoryProtocol.Repositories;

namespace TheoryProtocol.Services
{
    public class CommentService
    {
        private readonly CommentRepository _repository;
        private string _idDocumentName = "commentsId";
        public CommentService(CommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Comment>> GetCommentsByConnectionAsync(int connectionId)
        {
            return await _repository.GetByFieldIdAsync("ConnectionId",connectionId);
        }

        public async void AddComment(Comment comment)
        {
            int prevId = await _repository.GetIdAsync(_idDocumentName);
            comment.Id = prevId + 1;
            await _repository.UpdateIdAsync(_idDocumentName);
            await _repository.AddAsync(comment);
        }
    }
}
