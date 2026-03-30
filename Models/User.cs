using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(4, ErrorMessage = "La contraseña debe tener al menos 4 caracteres")]
        public string Password { get; set; }
    }
}