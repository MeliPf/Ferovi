﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.EF;

[Table("Iconos", Schema = "Plat")]
public partial class Iconos
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Class { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Paquete { get; set; }

    [InverseProperty("IdIconoNavigation")]
    public virtual ICollection<MenuPrincipal> MenuPrincipal { get; set; } = new List<MenuPrincipal>();
}