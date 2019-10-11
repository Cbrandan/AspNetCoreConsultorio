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
            var model = new PacientesViewModel() {
                ListaPacientes = ItemsPacientes
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        //Lo que recibo como parametro es un Model Paciente que se llama "newPaciente"
        public async Task<IActionResult> AddPaciente(Paciente newPaciente)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Pacientes");
            }
            //Si el Model es valido, lo que hago es llamar al método AddPacienteAsync definido en la
            // variable _PacienteItemService del tipo Interfaz (IPacienteItemAsync)
            var successful = await _PacienteItemService.AddPacienteAsync(newPaciente);
            if (!successful)
            {
                return BadRequest("No se pudo agregar al paciente.");
            }
            return RedirectToAction("Pacientes");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarPaciente(int dniPaciente)
        {
            var borrado = await _PacienteItemService.BorrarPaciente(dniPaciente);
            if (!borrado)
            {
                return BadRequest($"No se pudo eliminar al paciente con DNI....");
            }

            return RedirectToAction("Pacientes");

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Paciente(int dniPaciente)
        {
            var ItemPaciente = await _PacienteItemService.GetPacienteAsync(dniPaciente);
            var model = new Paciente()
            {
                DNI = ItemPaciente.DNI,
                Apellido = ItemPaciente.Apellido,
                Nombre = ItemPaciente.Nombre,
                Sexo = ItemPaciente.Sexo,
                Fecha_Nacimiento = ItemPaciente.Fecha_Nacimiento,
                Fecha_Alta = ItemPaciente.Fecha_Alta
    };

            return View("AddPacientePartial", model);




        }




    }
}