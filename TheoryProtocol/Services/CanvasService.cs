using TheoryProtocol.Models;
using TheoryProtocol.Repositories;

namespace TheoryProtocol.Services
{
    public class CanvasService
    {
        private readonly CanvasRepository _repository;
        private string _idDocumentName;
        public CanvasService(CanvasRepository repository)
        {
            _repository = repository;
            _idDocumentName = "canvasId";
        }

        public async Task<List<Models.Canvas>> GetCanvas()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddCanvas(Canvas canvas)
        {
            int prevId = await _repository.GetIdAsync(_idDocumentName);
            Canvas newCanvas = canvas;
            newCanvas.Id = prevId+1;
            await _repository.AddAsync(canvas);
            await _repository.UpdateIdAsync(_idDocumentName);
        }

    }
}
