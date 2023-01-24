using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Core_MVC.Models;

public partial class User
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nombre de Usuario")]
    public string Username { get; set; } = null!;

    [Required]
    [Display(Name = "Correo Electronico")]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = "Contraseña")]
    public string Password { get; set; } = null!;

    public byte Active { get; set; }

    public int? ProfileId { get; set; }
}
