using Pilotos.Models;

namespace Pilotos.Dtos
{
    public class PostPilotoDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }       
        public int NacionalidadId { get; set; }
        public int CantHorasVuelo { get; set; }

    }
}
