using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Core_MVC.Models;

public partial class Profile
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Perfil")]
    public string Name { get; set; } = null!;

    [Required]
    [Display(Name = "Acceso a")]
    public string? Menus { get; set; }

    public byte Active { get; set; }
}
