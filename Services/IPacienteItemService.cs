using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreConsultorio.Models;
using AspNetCoreConsultorio.Models.Pacientes;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreConsultorio.Services
{
    public interface IPacienteItemService
    {
        Task<Paciente[]> GetPacientesAsync();
        Task<bool> AddPacienteAsync(Paciente newPaciente, IdentityUser user);
        Task<bool> BorrarPacienteAsync(int dni);
        Task<Paciente> GetPacienteAsync(int dni);
        Task<bool> ModifyPacienteAsync(PacienteAddViewModel modPaciente);
    }
}