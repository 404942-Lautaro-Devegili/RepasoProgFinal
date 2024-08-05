namespace APIBack.Model
{
    public class Sucursal
    {
        public Sucursal()
        {
            Empleados = new HashSet<Empleado>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid IdCiudad { get; set; }
        public virtual Ciudad Ciudad { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
