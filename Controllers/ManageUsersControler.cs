using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AspNetCoreConsultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreConsultorio.Controllers
{
    [Authorize(Roles = AspNetCoreConsultorio.Data.Constantes.AdministratorRole)]
    //[Authorize]
    public class ManageUsersControler : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public ManageUsersControler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<IActionResult> AdmUsers()
        {
            var admins   = (await _userManager
                                .GetUsersInRoleAsync(AspNetCoreConsultorio.Data.Constantes.AdministratorRole))
                                .ToArray();

            var medicos  = (await _userManager
                                .GetUsersInRoleAsync(AspNetCoreConsultorio.Data.Constantes.MedicosRole))
                                .ToArray();

            var everyone = await _userManager.Users.ToArrayAsync();

            var model = new AdministrarUsuariosViewModel
            {
                Administrators = admins,
                Medicos        = medicos,
                Everyone       = everyone
            };

            return View("/Views/Usuarios/ManageUsers.cshtml", model);
        }
}
}