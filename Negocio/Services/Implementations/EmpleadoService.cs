using Negocio.Entities;
using Negocio.Models;
using Negocio.Services.Interfaces;
using Negocio.Repositories.Interfaces;

namespace Negocio.Services.Implementations
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<IEnumerable<EmpleadoDTO>> GetAllAsync()
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            return empleados.Select(e => new EmpleadoDTO
            {
                IdEmpleado = e.IdEmpleado,
                Nombre = e.Nombre
            });
        }

        public async Task<EmpleadoDTO?> GetByIdAsync(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);
            if (empleado == null) return null;

            return new EmpleadoDTO
            {
                IdEmpleado = empleado.IdEmpleado,
                Nombre = empleado.Nombre
            };
        }

        public async Task AddAsync(EmpleadoDTO empleadoDto)
        {
            var empleado = new Empleado
            {
                Nombre = empleadoDto.Nombre
            };

            await _empleadoRepository.AddAsync(empleado);
        }
    }
}
