using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreConsultorio.Models;

namespace AspNetCoreConsultorio.Services
{
    public interface IPacienteItemService
    {
        Task<Paciente[]> GetPacientesAsync();
        Task<bool> AddPacienteAsync(Paciente newPaciente);
        Task<bool> BorrarPacienteAsync(int dni);
        Task<Paciente> GetPacienteAsync(int dni);
        Task<bool> ModifyPacienteAsync(Paciente modPaciente);
    }
}