using APIBack.DTOs;
using APIBack.Model;
using APIBack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("TraerEmpleados")]
        public async Task<IActionResult> GetEmpleados()
        {
            try
            {
                return Ok(await _empleadoService.GetEmpleados());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("TraerEmpleadoById/{id}")]
        public async Task<IActionResult> GetEmpleado(Guid id)
        {
            var empleado = await _empleadoService.GetEmpleado(id);

            if (empleado == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CrearEmpleado")]
        public async Task<IActionResult> CrearEmpleado(PostEmpleadoDTO empleado)
        {
            try
            {
                await _empleadoService.CreateEmpleado(empleado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool EmpleadoExists(Guid id)
        {
            return _empleadoService.GetEmpleado(id) != null;
        }
    }
}
