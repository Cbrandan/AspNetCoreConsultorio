using AspNetCoreConsultorio.Models.Sexos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreConsultorio.Data
{
    public static class AppInitializer
    {
        public static void Initialize(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            if (!context.Roles.Any())
                SeedRole(roleManager);
            if (!context.Users.Any())
                SeedUser(userManager);
            if (!context.TablaSexos.Any())
                SeedTablaSexos(context);
        }

        private static void SeedRole(RoleManager<IdentityRole> roleManager)
        {
            //throw new NotImplementedException();
            if (roleManager.Roles
                .Where(x => x.Name == Constantes.AdministratorRole)
                .SingleOrDefaultAsync().Result != null) return;

            var testAdmin = new IdentityRole
            {
                Name = Constantes.AdministratorRole,
                NormalizedName = Constantes.AdministratorRole.ToUpper()
            };

            IdentityResult result = roleManager.CreateAsync(testAdmin).Result;
        }

        private static void SeedUser(UserManager<IdentityUser> userManager)
        {
            var userAdmin = "admin@pacientes.local";
            //throw new NotImplementedException();
            if (userManager.Users
                    .Where(x => x.UserName == userAdmin)
                    .SingleOrDefaultAsync().Result != null) return;

            var testAdmin = new IdentityUser
            {
                UserName = userAdmin,
                Email = userAdmin
            };

            IdentityResult result = userManager.CreateAsync(testAdmin, "NotSecure123!!").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(testAdmin, Constantes.AdministratorRole).Wait();
            }
        }

        private static void SeedTablaSexos(ApplicationDbContext context)
        {
            //throw new NotImplementedException();
            context.AddRangeAsync(new List<Sexo>
            {
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
            });

            context.SaveChangesAsync();
        }
    }
}
