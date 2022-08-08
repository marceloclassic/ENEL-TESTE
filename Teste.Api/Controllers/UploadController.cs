using Microsoft.AspNetCore.Mvc;
using Teste.Domain.Interfaces;

namespace Teste.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;

        public UploadController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]List<decimal> values)
        {
            try
            {
                _calculadoraService.AplicarTaxa(values);
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}