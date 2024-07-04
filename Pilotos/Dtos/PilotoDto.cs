using Pilotos.Models;

namespace Pilotos.Dtos
{
    public class PilotoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Nacionalidad { get; set; }
        public int CantHorasVuelo { get; set; }
    }
}
