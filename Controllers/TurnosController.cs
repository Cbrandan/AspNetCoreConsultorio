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
    public class TurnosController: Controller
    {
        private readonly ITurnoItemService _TurnoItemService;
        public TurnosController(ITurnoItemService TurnoItemService)
        {
            _TurnoItemService = TurnoItemService;
        }
         public async Task<IActionResult> Turnos()
        {
            var ItemsTurnos = await _TurnoItemService.GetTurnosAsync();
            var model = new TurnosViewModel(){
                ListaTurnos = ItemsTurnos
            };
            return View(model);
        }
    }
}