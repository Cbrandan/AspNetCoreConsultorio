using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreConsultorio.Models;
using AspNetCoreConsultorio.Models.Sexos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreConsultorio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Sexo> TablaSexos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Sexo>().HasData(
               new Sexo
               {
                   Id = Guid.NewGuid(),
                   Name = "Masculino"
               },

               new Sexo
               {
                   Id = Guid.NewGuid(),
                   Name = "Femenino"
               }
            );
            // ...
        }
    }
}
