using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using CursoEntityCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityCore.Controllers
{
    public class DetalleUsuarioController : Controller
    {
        public readonly ApplicationDbContext _contexto;
        public DetalleUsuarioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Opción 1 sin datos relacionados (solo trae ID de la categoria)
            //List<Articulo> listaArticulos =  _contexto.Articulo.ToList();

            //foreach (var articulo in listaArticulos)
            //{
                //Opción 2: Carga manual se genera muchas consultas SQL, no es eficiente si necesitamos cargar mas propiedades
                //articulo.Categoria = _contexto.Categoria.FirstOrDefault(c => c.Categoria_Id == articulo.Categoria_Id);

                //Opción 3: Carga explícita (Explicit loading)
            //    _contexto.Entry(articulo).Reference(c => c.Categoria).Load();
            //}

            //Opción 4: Carga diligente (Eager Loading)
            List<Articulo> listaArticulos = _contexto.Articulo.Include(c => c.Categoria).ToList();

            return View(listaArticulos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _contexto.Categoria.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });

            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Articulo Articulo)
        {
            if (ModelState.IsValid)
            {
                _contexto.Articulo.Add(Articulo);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            //Para que al retornar la vista por alguno error se envíe la lista de categorias 
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _contexto.Categoria.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });

            return View(articuloCategorias);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _contexto.Categoria.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });

            articuloCategorias.Articulo = _contexto.Articulo.FirstOrDefault(c => c.Articulo_Id == id);

            if (articuloCategorias == null)
            {
                return NotFound();
            }

            return View(articuloCategorias);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ArticuloCategoriaVM articuloVM)
        {
            if (ModelState.IsValid)
            {
                if (articuloVM.Articulo.Articulo_Id == 0)
                {
                    return View(articuloVM.Articulo);
                }
                else
                {
                    _contexto.Articulo.Update(articuloVM.Articulo);
                    _contexto.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(articuloVM.Articulo);

        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var Articulo = _contexto.Articulo.FirstOrDefault(c => c.Articulo_Id == id);
            _contexto.Remove(Articulo);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
