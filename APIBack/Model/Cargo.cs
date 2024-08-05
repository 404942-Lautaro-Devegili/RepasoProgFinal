namespace APIBack.Model
{
    public class Cargo
    {
        public Cargo()
        {
            Empleados = new HashSet<Empleado>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
