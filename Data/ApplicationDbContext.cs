using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreConsultorio.Models;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
        base.OnModelCreating(builder);
        // ...
        }
        public DbSet<Paciente> Pacientes { get; set; }

    }
}
