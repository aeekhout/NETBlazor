using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Data
{
    public class Curso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Profesor { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "E-Mail Incorrecto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int Precio { get; set; }

        public DateTime Fecha_Ingreso { get; set; }

        public DateTime Fecha_Update { get; set; }

    }
        
}
