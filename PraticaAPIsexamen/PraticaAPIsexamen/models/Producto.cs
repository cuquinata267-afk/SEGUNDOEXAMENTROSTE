namespace PraticaAPIsexamen.models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DescripcionCorta { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; } = 0;
        public int idCategoria { get; set; }
    }
}
