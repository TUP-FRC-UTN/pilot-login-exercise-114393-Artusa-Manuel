using Pilotos.Models;

namespace Pilotos.Repositories
{
    public interface INacionalidadRepository
    {
        Task<List<Nacionalidad>> GetAllAsync();
    }
}
