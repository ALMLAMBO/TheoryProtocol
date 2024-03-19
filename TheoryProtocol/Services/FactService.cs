using TheoryProtocol.Models;
using TheoryProtocol.Repositories;

namespace TheoryProtocol.Services
{
    public class FactService
    {
        private readonly FactRepository _repository;
        private string _idDocumentName = "factsId";
        public FactService(FactRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Fact>> GetFactsByCanvasAsync(int canvasId)
        {
            return await _repository.GetByFieldIdAsync("CanvasId",canvasId);
        }

        public async Task AddFact(Fact fact)
        {
            int prevId = await _repository.GetIdAsync(_idDocumentName);
            fact.Id = prevId + 1;
            await _repository.UpdateIdAsync(_idDocumentName);
            await _repository.AddAsync(fact);
        }
    }
}
