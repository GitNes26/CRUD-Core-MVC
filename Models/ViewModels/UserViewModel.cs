using System.ComponentModel.DataAnnotations;

namespace CRUD_Core_MVC.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string Username { get; set; } = null!;

        [Required]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = null!;

        [Required]
        [Display(Name = "Perfil asignado")]
        public int? ProfileId { get; set; }
    }
}
