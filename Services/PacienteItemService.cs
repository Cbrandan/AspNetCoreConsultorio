using AspNetCoreConsultorio.Data;
using AspNetCoreConsultorio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<bool> BorrarPacienteAsync(int dni)
        {
            //_context.Pacientes.Find(dni);
            //return true;
            _context.RemoveRange(_context.Pacientes.Where(x => x.DNI == dni));
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<Paciente> GetPacienteAsync(int dni)
        {
            var paciente = await _context.Pacientes.Where(x => x.DNI == dni).FirstOrDefaultAsync();
            return paciente;
        }

        public async Task<bool> ModifyPacienteAsync(Paciente modPaciente)
        {
            var paciente = await _context.Pacientes.Where(x => x.DNI == modPaciente.DNI).FirstOrDefaultAsync();

            if (paciente == null)
                return false;

            paciente.Apellido = modPaciente.Apellido;
            paciente.Nombre = modPaciente.Nombre;
            paciente.Sexo = modPaciente.Sexo;
            paciente.Fecha_Nacimiento = modPaciente.Fecha_Nacimiento;
            paciente.Fecha_Alta = modPaciente.Fecha_Alta;

            //_context.Pacientes.UpdateRange(paciente);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }
    }
}