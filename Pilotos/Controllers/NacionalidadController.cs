using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pilotos.Repositories;

namespace Pilotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadController : ControllerBase
    {
        private readonly INacionalidadRepository _nacionalidadRepository;
        private readonly IMapper _mapper;

        public NacionalidadController(INacionalidadRepository nacionalidadRepository, IMapper mapper)
        {
            _mapper = mapper;
            _nacionalidadRepository = nacionalidadRepository;
        }
        [HttpGet("/Nacionalidades/GetAll")]
        public async Task<IActionResult> GetAll() { 

            var response = await _nacionalidadRepository.GetAllAsync();
            return Ok(response);
        }
    }
}
