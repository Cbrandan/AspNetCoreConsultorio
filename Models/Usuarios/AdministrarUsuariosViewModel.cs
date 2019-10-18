using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreConsultorio.Models
{
    public class AdministrarUsuariosViewModel{
        public IdentityUser[] Administrators { get; set; }
        public IdentityUser[] Everyone { get; set;}
    }
}