using AspNetCoreConsultorio.Data;
using AspNetCoreConsultorio.Models;
using AspNetCoreConsultorio.Models.Pacientes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreConsultorio.Services
{
    public class PacienteItemService : IPacienteItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly ISexoService _iSexoService;

        public PacienteItemService(
            ApplicationDbContext context,
            ISexoService sexoService)
        {
            _context = context;
            _iSexoService = sexoService;
        }

        public async Task<bool> AddPacienteAsync(Paciente newPaciente, IdentityUser user)
        {
            //throw new NotImplementedException();
            newPaciente.Fecha_Alta = DateTime.Now;
            newPaciente.UserId = user.Id;
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
            var paciente = await _context.Pacientes
            .Include(p=> p.Sexo)
            .Where(x => x.DNI == dni).FirstOrDefaultAsync();
            return paciente;
        }

        public async Task<bool> ModifyPacienteAsync(PacienteAddViewModel modPaciente)
        {
            var paciente = await _context.Pacientes
                .Include(p => p.Sexo)
                .Where(x => x.DNI == modPaciente.DNI).FirstOrDefaultAsync();

            if (paciente == null)
                return false;

            paciente.Apellido = modPaciente.Apellido;
            paciente.Nombre = modPaciente.Nombre;
            paciente.Sexo = await _iSexoService.GetSexosByIdAsync(modPaciente.SexoId);
            paciente.Fecha_Nacimiento = modPaciente.Fecha_Nacimiento;
            paciente.Fecha_Alta = modPaciente.Fecha_Alta;
            
            _context.Pacientes.UpdateRange(paciente);
            
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }
    }
}