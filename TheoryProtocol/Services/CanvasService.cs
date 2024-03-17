using TheoryProtocol.Models;
using TheoryProtocol.Repositories;

namespace TheoryProtocol.Services
{
    public class CanvasService
    {
        private readonly CanvasRepository _repository;
        public CanvasService(CanvasRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Models.Canvas>> GetCanvas()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddCanvas(Canvas canvas)
        {
            await _repository.AddAsync(canvas);
        }

    }
}
