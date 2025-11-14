using Microsoft.AspNetCore.Mvc;
using PraticaAPIsexamen.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PraticaAPIsexamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {


        //Base de datos simulada porque estamos usando memoria que es lo mas sencillo y facil de aplicar por alguna razon la base de datos no quiere migrar :(
        private static List<Proveedor> _proveedores = new List<Proveedor>
        {
            new Proveedor{Id= 1, RazonSocial= "Comestibles", NumeroContacto = 63762664, ProductosIds = new List<int> { 1 } },
            new Proveedor{Id= 1, RazonSocial= "Productos de limpieza", NumeroContacto = 63762664, ProductosIds = new List<int> { 2 } }
        };
        private static List<Producto> _productos = new List<Producto>
        {
            new Producto {Id= 2, Nombre= "Papas", DescripcionCorta= "Papas fritas", Precio= 5, Stock= 10, idCategoria=1 },
            new Producto {Id= 1, Nombre= "Shampoo", DescripcionCorta= "Shampoo sedal", Precio= 50, Stock = 20, idCategoria=2 }
        };

        // 1. (Traer a todos)
        [HttpGet]
        public ActionResult<IEnumerable<Proveedor>> GetProveedor()
        {
            return Ok(_proveedores);
        }


        //2
        [HttpGet("{id}")]
        public ActionResult<Proveedor> GetUsuario(int id)
        {
            var proveedor = _proveedores.FirstOrDefault(u => u.Id == id);

            if (proveedor == null)
            {
                return NotFound("Usuario no encontrado, bestie. 💔");
            }

            return Ok(proveedor);
        }
        // Un GET para ver los productos disponibles de proveedor 
        [HttpGet("productos")]
        public ActionResult<IEnumerable<Producto>> GetProductos()
        {
            return Ok(_productos);
        }

    }
}


