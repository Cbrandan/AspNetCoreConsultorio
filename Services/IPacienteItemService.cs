using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreConsultorio.Models;

namespace AspNetCoreConsultorio.Services
{
    public interface IPacienteItemService
    {
        Task<Paciente[]> GetIncompleteItemAsync();
    }
}