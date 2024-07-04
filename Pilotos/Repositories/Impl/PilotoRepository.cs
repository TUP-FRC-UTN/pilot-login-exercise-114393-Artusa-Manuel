using Microsoft.EntityFrameworkCore;
using Pilotos.Context;
using Pilotos.Models;

namespace Pilotos.Repositories.Impl
{
    public class PilotoRepository : IPilotoRepository
    {
        private readonly PilotosContext _context;
        public PilotoRepository(PilotosContext context)
        {
            _context = context;
        }
        public async Task<Piloto> CreatePilotoAsync(Piloto piloto)
        {
            await _context.pilotos.AddAsync(piloto);
            int filasAfectadas = await _context.SaveChangesAsync();
            if (filasAfectadas == 1)
            {
                return piloto;
            }
            else { return null; }

        }

        public async Task<Piloto> DeletePilotoAsync(int id)
        {
            var piloto = await _context.pilotos.FirstOrDefaultAsync(x => x.Id == id);
            if (piloto != null)
            {
                _context.Remove(piloto);
                var response = _context.SaveChanges();
                if (response != 0)
                {
                    return piloto;
                }

            }
            return null;
            
        }

        public async Task<List<Piloto>> GetAllAsync()
        {
            return await _context.pilotos
                .Include(p => p.Nacionalidad)
                .ToListAsync();
        }

        public async Task<Piloto> GetPilotoAsync(int id)
        {
            var pilotoEntidad = await _context.pilotos.FirstOrDefaultAsync(p => p.Id == id);
            if (pilotoEntidad != null)
            {
                return pilotoEntidad;
            }
            return null;
        }

        public Task<Piloto> UpdatePilotoAsync(Piloto piloto)
        {
            throw new NotImplementedException();
        }
    }
}
