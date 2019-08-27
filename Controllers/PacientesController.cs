using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreConsultorio.Models;
using AspNetCoreConsultorio.Services;

namespace AspNetCoreConsultorio.Controllers
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
            var ItemsPacientes = await _PacienteItemService.GetPacientesAsync();
            var model = new PacientesViewModel(){
                ListaPacientes = ItemsPacientes
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPaciente(Paciente newPaciente)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Paciente");
            }
            var successful = await _PacienteItemService.AddPacienteAsync(newPaciente);
            if (!successful)
            {
                return BadRequest("No se pudo agregar al paciente.");
            }
            return RedirectToAction("Paciente");
        }
    }
}