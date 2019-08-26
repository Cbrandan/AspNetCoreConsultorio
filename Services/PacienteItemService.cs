using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreConsultorio.Data;
using AspNetCoreConsultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreConsultorio.Services
{
    class PacienteItemService : IPacienteItemService
    {
        private readonly ApplicationDbContext _context;

        public PacienteItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPacienteAsync(Paciente newPaciente)
        {
            //throw new NotImplementedException();
            newPaciente.Fecha_Alta = DateTimeOffset.Now.Date;
            _context.Pacientes.Add(newPaciente);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<Paciente[]> GetPacientesAsync()
        {
            var paciente = await _context.Pacientes
                .ToArrayAsync();
            return paciente;
        }

    }
}