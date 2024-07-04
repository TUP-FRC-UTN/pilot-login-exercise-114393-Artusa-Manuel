using Pilotos.Models;

namespace Pilotos.Repositories
{
    public interface IPilotoRepository
    {
        Task<List<Piloto>> GetAllAsync();
        Task<Piloto> CreatePilotoAsync(Piloto piloto);
        Task<Piloto> UpdatePilotoAsync(Piloto piloto);
        Task<Piloto> DeletePilotoAsync(int id);
        Task<Piloto> GetPilotoAsync(int id);
    }
}
