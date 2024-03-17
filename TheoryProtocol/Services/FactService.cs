using TheoryProtocol.Models;
using TheoryProtocol.Repositories;

namespace TheoryProtocol.Services
{
    public class FactService
    {
        private readonly FactRepository _repository;
        public FactService(FactRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Fact>> GetFactsByCanvasAsync(int canvasId)
        {
            return await _repository.GetByFieldIdAsync("CanvasId",canvasId);
        }

        public async void AddFact(Fact fact)
        {
            await _repository.AddAsync(fact);
        }
    }
}
