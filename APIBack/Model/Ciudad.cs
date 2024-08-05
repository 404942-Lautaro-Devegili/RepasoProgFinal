namespace APIBack.Model
{
    public class Ciudad
    {
        public Ciudad()
        {
            Sucursales = new HashSet<Sucursal>();
        }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        
        public virtual ICollection<Sucursal> Sucursales { get; set; }
    }
}
