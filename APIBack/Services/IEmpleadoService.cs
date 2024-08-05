using APIBack.DTOs;
using APIBack.Model;

namespace APIBack.Services
{
    public interface IEmpleadoService
    {
        Task<List<GetEmpleadoDTO>> GetEmpleados();
        Task<GetEmpleadoDTO> GetEmpleado(Guid id);
        Task<bool> CreateEmpleado(PostEmpleadoDTO empleado);
    }
}
