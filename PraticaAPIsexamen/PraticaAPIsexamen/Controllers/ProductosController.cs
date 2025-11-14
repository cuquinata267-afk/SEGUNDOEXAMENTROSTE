using Microsoft.AspNetCore.Mvc;
using PraticaAPIsexamen.models;
using Microsoft.AspNetCore.Http;
namespace PraticaAPIsexamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        //Base de datos simulada porque estamos usando memoria que es lo mas sencillo y facil de aplicar por alguna razon la base de datos no quiere migrar :(
        private static List<Categoria> _categorias = new List<Categoria>
        {
            new Categoria {Id= 1, Nombre= "Comestibles", Descripcion = "Productos alimenticios"  },
            new Categoria {Id= 1, Nombre= "Productos de limpieza", Descripcion = "Productos para aseo personal" }
        };
        private static List<Producto> _productos = new List<Producto>
        {
            new Producto {Id= 2, Nombre= "Papas", DescripcionCorta= "Papas fritas", Precio= 5, Stock= 10, idCategoria=1 },
            new Producto {Id= 1, Nombre= "Shampoo", DescripcionCorta= "Shampoo sedal", Precio= 50, Stock = 20, idCategoria=2 }
        };

        // 1. (Traer a todos)
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetProducto()
        {
            return Ok(_productos);
        }

        // 2.  (Traer uno solo por ID)
        [HttpGet("{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            var producto = _productos.FirstOrDefault(u => u.Id == id);

            if (producto == null)
            {
                return NotFound("Producto no encontrado");
            }

            return Ok(producto);
        }

        // 3 (Crear nuevo)
        [HttpPost]
        public ActionResult<Producto> PostProducto(Producto nuevoProducto)
        {
            // El 'nuevoUsuario' que llega desde Swagger ya debe traer la lista de IDs
            nuevoProducto.Id = _productos.Count > 0 ? _productos.Max(u => u.Id) + 1 : 1;

            _productos.Add(nuevoProducto);

            return CreatedAtAction(nameof(GetProducto), new { id = nuevoProducto.Id }, nuevoProducto);
        }


        // 4 (Editar - "Reforma")
        [HttpPut("{id}")]
        public IActionResult PutProducto(int id, Producto productoActualizado)
        {
            var productoExistente = _productos.FirstOrDefault(u => u.Id == id);

            if (productoExistente == null)
            {
                return NotFound();
            }

            // Actualizamos los datos
            productoExistente.Nombre = productoActualizado.Nombre;
            productoExistente.DescripcionCorta = productoActualizado.DescripcionCorta;
            productoExistente.Precio = productoActualizado.Precio;
            productoExistente.Stock = productoActualizado.Stock;

            // ¡Aquí actualizamos la lista completa de roles!
            productoExistente.idCategoria =productoActualizado.idCategoria;

            return NoContent(); // Código 204
        }

        // 5. DELETE: api/productos/5 (Eliminar)
        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            var producto = _productos.FirstOrDefault(u => u.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            _productos.Remove(producto);

            return NoContent();
        }

        //GET para ver los categorias disponibles (¡buena práctica!)
        [HttpGet("categorias")]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            return Ok(_categorias);
        }

    } 
}