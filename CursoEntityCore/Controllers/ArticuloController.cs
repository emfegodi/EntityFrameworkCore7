using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoEntityCore.Controllers
{
    public class ArticuloController : Controller
    {
        public readonly ApplicationDbContext _contexto;
        public ArticuloController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Index()
        {
            //Consulta inicial con todos los datos
            List<Articulo> listaArticulos = _contexto.Articulo.ToList();

            return View(listaArticulos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
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
            return View();
        }

        [HttpGet]
        public IActionResult CrearMultipleOpcion2()
        {
            List<Articulo> Articulos = new List<Articulo>();
            for (int i = 0; i < 2; i++)
            {
                //_contexto.Articulo.Add(new Articulo{Nombre = Guid.NewGuid().ToString(),});
                Articulos.Add(new Articulo { TituloArticulo = Guid.NewGuid().ToString() });
            }
            _contexto.AddRange(Articulos);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult CrearMultipleOpcion5()
        {
            for (int i = 0; i < 5; i++)
            {
                _contexto.Articulo.Add(new Articulo
                {
                    TituloArticulo = Guid.NewGuid().ToString(),
                });
            }

            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult VistaCrearMultipleOpcionFormulario()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CrearMultipleOpcionFormulario()
        {
            string ArticulosForm = Request.Form["Nombre"];
            var listaArticulos = from val in ArticulosForm.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) select (val);

            List<Articulo> Articulos = new List<Articulo>();

            foreach (var Articulo in listaArticulos)
            {
                Articulos.Add(new Articulo { TituloArticulo = Articulo });
            }
            _contexto.Articulo.AddRange(Articulos);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var Articulo = _contexto.Articulo.FirstOrDefault(c => c.Articulo_Id == id);
            return View(Articulo);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Articulo Articulo)
        {
            if (ModelState.IsValid)
            {
                _contexto.Articulo.Update(Articulo);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(Articulo);

        }

        [HttpGet]
        public IActionResult Borrar(int id)
        {
            var Articulo = _contexto.Articulo.FirstOrDefault(c => c.Articulo_Id == id);
            _contexto.Remove(Articulo);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult BorrarMultiple2()
        {
            IEnumerable<Articulo> Articulos = _contexto.Articulo.OrderByDescending(c => c.Articulo_Id).Take(2); ;
            _contexto.RemoveRange(Articulos);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult BorrarMultiple5()
        {
            IEnumerable<Articulo> Articulos = _contexto.Articulo.OrderByDescending(c => c.Articulo_Id).Take(5); ;
            _contexto.RemoveRange(Articulos);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
