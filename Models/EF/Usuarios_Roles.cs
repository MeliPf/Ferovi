﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.EF;

[Table("Usuarios_Roles", Schema = "Plat")]
public partial class Usuarios_Roles
{
    [Key]
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    [ForeignKey("IdRol")]
    [InverseProperty("Usuarios_Roles")]
    public virtual Roles IdRolNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Usuarios_Roles")]
    public virtual Usuarios IdUsuarioNavigation { get; set; }
}