namespace APIBack.DTOs
{
    public class PostEmpleadoDTO
    {
        public Guid? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public Guid? IdCargo { get; set; }
        public Guid? IdSucursal { get; set; }
        public string? DNI { get; set; }
        public DateTime? FechaAlta { get; set; }
        public Guid? IdJefe { get; set; }
    }
}
