namespace PraticaAPIsexamen.models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = string.Empty; // Ej: "Admin", "Mortal"
        public int NumeroContacto { get; set; } = 0;
        public List<int> ProductosIds { get; set; } = new List<int>();
    }
}
