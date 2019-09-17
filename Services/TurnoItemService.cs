using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreConsultorio.Data;
using AspNetCoreConsultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreConsultorio.Services
{
    class TurnoItemService : ITurnoItemService
    {
        private readonly ApplicationDbContext _context;

        public TurnoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

/*         public async Task<bool> AddPacienteAsync(Paciente newPaciente)
        {
            //throw new NotImplementedException();
            newPaciente.Fecha_Alta = DateTimeOffset.Now.Date;
            _context.Pacientes.Add(newPaciente);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        } */

        public async Task<Turno[]> GetTurnosAsync()
        {
            var turno = await _context.Turnos
                .ToArrayAsync();
            return turno;
        }

    }
}