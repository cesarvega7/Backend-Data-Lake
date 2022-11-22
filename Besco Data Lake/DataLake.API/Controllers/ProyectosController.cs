using DataLake.Dto.Response;
using DataLake.Entities.Complex;
using DataLake.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataLake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : Controller
    {
        private readonly IProyectosService _service;

        public ProyectosController(IProyectosService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponseEntity<ICollection<ProyectosInfo?>>), 200)]
        public async Task<IActionResult> Get()
        {
            var lst = await _service.GetCollectionAsync();
            return Ok(lst);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseResponseEntity<PeriodoInfo?>), 200)]
        [ProducesResponseType(typeof(BaseResponseEntity<PeriodoInfo?>), 404)]
        public async Task<IActionResult> Get(int id)
        {
            var lst = await _service.GetByIdAsync(id);
            if (lst.ResponseResult == null) return NotFound(lst);
            return Ok(lst);
        }

    }
}
