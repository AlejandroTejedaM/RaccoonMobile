using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaccoonMobile.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "El campo Email es requerido")]
        public String Email { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es requerido")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public TipoUsuario Tipo { get; set; }

    }
}