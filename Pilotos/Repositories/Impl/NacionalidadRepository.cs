using Microsoft.EntityFrameworkCore;
using Pilotos.Context;
using Pilotos.Models;

namespace Pilotos.Repositories.Impl
{
    public class NacionalidadRepository : INacionalidadRepository
    {
        private readonly PilotosContext _context;
        public NacionalidadRepository(PilotosContext context)
        {
            _context = context;
        }
        public async Task<List<Nacionalidad>> GetAllAsync()
        {
            return await _context.nacionalidades.ToListAsync();
        }
    }
}
