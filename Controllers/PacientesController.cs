using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreConsultorio.Models;
using AspNetCoreConsultorio.Services;
using AspNetCoreConsultorio.Models.Pacientes;

namespace AspNetCoreConsultorio.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteItemService _PacienteItemService;
        private readonly  ISexoService _sexoService;
        public PacientesController(IPacienteItemService PacienteItemService, ISexoService sexoService)
        {
            _PacienteItemService = PacienteItemService;
            _sexoService = sexoService;

        }

        public async Task<IActionResult> Pacientes()
        {
            var ItemsPacientes = await _PacienteItemService.GetPacientesAsync();
            var model = new PacientesViewModel() {
                ListaPacientes = ItemsPacientes
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddPaciente(PacienteAddViewModel ModelPaciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var newPaciente = new Paciente{
                DNI              = ModelPaciente.DNI,
                Apellido         = ModelPaciente.Apellido,
                Nombre           = ModelPaciente.Nombre,
                Sexo             = _sexoService.GetSexosByIdAsync(ModelPaciente.SexoId).Result,
                Fecha_Nacimiento = ModelPaciente.Fecha_Nacimiento
            };

            var successful = await _PacienteItemService.AddPacienteAsync(newPaciente);
            if (!successful)
            {
                return BadRequest("No se pudo agregar al paciente.");
            }
            return RedirectToAction("Pacientes");
        }

        [HttpGet]
        public async Task<ViewResult> AddPaciente()
        {
            // Paciente Model = new Paciente();
            PacienteAddViewModel Model = new PacienteAddViewModel{
                Fecha_Nacimiento = DateTime.Now,
                Sexos = await _sexoService.GetSexosAsync()
            };

            return View("AddPacientePartial", Model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarPaciente(int dniPaciente)
        {
            var borrado = await _PacienteItemService.BorrarPacienteAsync(dniPaciente);
            if (!borrado)
            {
                return BadRequest($"No se pudo eliminar al paciente con DNI....");
            }

            return RedirectToAction("Pacientes");

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Paciente(int dniPaciente, char Modo)
        {
            var ItemPaciente = await _PacienteItemService.GetPacienteAsync(dniPaciente);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = new PacienteAddViewModel{
                DNI = ItemPaciente.DNI,
                Apellido = ItemPaciente.Apellido,
                Nombre = ItemPaciente.Nombre,
                SexoId = ItemPaciente.Sexo.Id,
                Sexos = await _sexoService.GetSexosAsync(),
                Fecha_Nacimiento = ItemPaciente.Fecha_Nacimiento,
                Fecha_Alta = ItemPaciente.Fecha_Alta
            };
            string vista = null;

            if (Modo == 'D')
            {
                vista = "DetailsPacientePartial";
            }
            else
            {
                if (Modo == 'M')
                {
                    vista = "ModifyPacientePartial";
                }
            }
            return View(vista, model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> ModifyPaciente(PacienteAddViewModel modPaciente)
        {
            if (!ModelState.IsValid)
            {
                //return RedirectToAction("Pacientes");
            }
            var successful = await _PacienteItemService.ModifyPacienteAsync(modPaciente);

            if (!successful)
            {
                return BadRequest("No se pudo modificar el paciente.");
            }
            return RedirectToAction("Pacientes");
        }
    }
}