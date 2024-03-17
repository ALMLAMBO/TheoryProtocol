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

        public async Task<List<Comment>> GetCommentsByCanvasAsync(int canvasId)
        {
            return await _repository.GetByFieldIdAsync("CanvasId",canvasId);
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
