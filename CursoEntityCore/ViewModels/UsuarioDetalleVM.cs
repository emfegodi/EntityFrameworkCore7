using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursoEntityCore.ViewModels
{
    public class UsuarioDetalleVM
    {
        public Usuario Usuario { get; set; }
        public DetalleUsuario DetalleUsuario { get; set; }
    }
}
