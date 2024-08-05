using APIBack.Context;
using APIBack.DTOs;
using APIBack.Model;
using Microsoft.EntityFrameworkCore;

namespace APIBack.Services.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly EmpleadosContext _context;

        public EmpleadoService(EmpleadosContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEmpleado(PostEmpleadoDTO empleado)
        {

            var empleadoEntity = new Empleado
            {
                Id = Guid.NewGuid(),
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                DNI = empleado.DNI,
                IdCargo = empleado.IdCargo,
                IdSucursal = empleado.IdSucursal,
                IdJefe = empleado.IdJefe,
                FechaAlta = DateTime.UtcNow
            };

            try
            {
                if (_context.Empleados.Find(empleadoEntity.Id) != null)
                {
                    return false;
                }
                await _context.Empleados.AddAsync(empleadoEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el empleado: {ex.Message}");
                return false;
            }
        }

        public async Task<GetEmpleadoDTO> GetEmpleado(Guid id)
        {
            var empleado = await _context.Empleados
                .Include(x => x.Cargo)
                .Include(x => x.Sucursal)
                .Select(x => new GetEmpleadoDTO
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    DNI = x.DNI,
                    FechaAlta = x.FechaAlta,
                    CargoId = x.Cargo.Id,
                    CargoNombre = x.Cargo.Nombre,
                    CiudadId = x.Sucursal.Ciudad.Id,
                    SucursalNombre = x.Sucursal.Nombre,
                    CiudadNombre = x.Sucursal.Ciudad.Nombre,
                    JefeId = x.IdJefe
                }).FirstOrDefaultAsync(x => x.Id == id);

            if (empleado == null)
            {
                return null;
            }

            return empleado;
        }

        public async Task<List<GetEmpleadoDTO>> GetEmpleados()
        {
            var empleados = await _context.Empleados
                  .Include(x => x.Cargo)
                  .Include(x => x.Sucursal)
                  .ThenInclude(s => s.Ciudad)
                  .Select(x => new GetEmpleadoDTO
                  {
                      Id = x.Id,
                      Nombre = x.Nombre,
                      Apellido = x.Apellido,
                      DNI = x.DNI,
                      FechaAlta = x.FechaAlta,
                      CargoId = x.Cargo.Id,
                      CargoNombre = x.Cargo.Nombre,
                      CiudadId = x.Sucursal.Ciudad.Id,
                      SucursalId = x.Sucursal.Id,
                      SucursalNombre = x.Sucursal.Nombre,
                      CiudadNombre = x.Sucursal.Ciudad.Nombre,
                      JefeId = x.IdJefe 
                  }).ToListAsync();
            return empleados;
        }
    }
}
