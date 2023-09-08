using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using CursoEntityCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityCore.Controllers
{
    public class UsuarioController : Controller
    {
        public readonly ApplicationDbContext _contexto;
        public UsuarioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Usuario> listaUsuarios = _contexto.Usuario.ToList();

            return View(listaUsuarios);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            Usuario Usuario = new Usuario();

            return View(Usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Usuario Usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Add(Usuario);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            

            var usuario = _contexto.Usuario.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.Id != 0)
                {
                    _contexto.Usuario.Update(usuario);
                    _contexto.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(usuario);

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
