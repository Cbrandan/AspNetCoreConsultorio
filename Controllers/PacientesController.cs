using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreConsultorio.Models;
using AspNetCoreConsultorio.Services;

namespace MiPrimerMVC.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteItemService _PacienteItemService;
        public PacientesController(IPacienteItemService PacienteItemService)
        {
            _PacienteItemService = PacienteItemService;
        }

         public async Task<IActionResult> Pacientes()
        {
            var ItemsPacientes = await _PacienteItemService.GetIncompleteItemAsync();
            var model = new PacientesViewModel(){
                ListaPacientes = ItemsPacientes
            };

            return View(model);
        }
    }
}