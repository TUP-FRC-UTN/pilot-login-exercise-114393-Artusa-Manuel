using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pilotos.Dtos;
using Pilotos.Models;
using Pilotos.Repositories;

namespace Pilotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotoController : ControllerBase
    {
        private readonly IPilotoRepository _pilotoRepository;
        private readonly IMapper _mapper;

        public PilotoController(IPilotoRepository pilotoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _pilotoRepository = pilotoRepository;
        }

        [HttpGet("/Pilotos/GetAll")]
        public async Task<IActionResult> getAllAsync()
        {
            List<PilotoDto> pilotosDto = new List<PilotoDto>();
            List<Piloto> pilotos = await _pilotoRepository.GetAllAsync();
            foreach (Piloto piloto in pilotos)
            {
                pilotosDto.Add(_mapper.Map<PilotoDto>(piloto));
            }
            return Ok(pilotosDto);
        }
        [HttpPost("/Pilotos/CrearPiloto")]
        public async Task<IActionResult> CrearPiloto([FromBody] PostPilotoDto pilotoNuevo)
        {

            Piloto piloto = _mapper.Map<Piloto>(pilotoNuevo);
            var result = await _pilotoRepository.CreatePilotoAsync(piloto);
           
            return Ok(result);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteLibro(int id)
        {
            var response = await _pilotoRepository.DeletePilotoAsync(id);
            if (response == null)
            {
                return BadRequest("NO SE ENCONTRO EL PILOTO");
            }

            return Ok(response);
        }
    }
}
