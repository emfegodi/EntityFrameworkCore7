using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    public class Categoria
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Categoria_Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido para crear la categoría")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText="[NULL]")]
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public bool Activo { get; set; }

        public List<Articulo> Articulo { get; set; }  
    }
}
