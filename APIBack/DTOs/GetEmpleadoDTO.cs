namespace APIBack.DTOs
{
    public class GetEmpleadoDTO
    {
        public Guid? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? DNI { get; set; }
        public DateTime? FechaAlta { get; set; }
        public Guid? CargoId { get; set; }
        public string? CargoNombre { get; set; }
        public Guid? CiudadId { get; set; }
        public string? CiudadNombre { get; set; }
        public Guid? SucursalId { get; set; }
        public string? SucursalNombre { get; set; }
        public Guid? JefeId { get; set; }
    }
}
