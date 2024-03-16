using TheoryProtocol.Models;
using TheoryProtocol.Repositories;

namespace TheoryProtocol.Services
{
    public class ConnectionService
    {
        private readonly ConnectionRepository _repository;
        public ConnectionService(ConnectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Connection>> GetConnectionsByCanvasAsync(int canvasId)
        {
            return await _repository.GetByFieldIdAsync("canvasId",canvasId);
        }
    }
}
