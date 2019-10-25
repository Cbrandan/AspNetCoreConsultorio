/* using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreConsultorio.Models;

namespace AspNetCoreConsultorio.Services
{
    class FakePacienteItemService : IPacienteItemService

    {
        public Task<Paciente[]> GetIncompleteItemAsync()
        {
            Paciente Paciente1 = new Paciente(
                80555111, 
                "Brandan", 
                "Fabrizio", 
                'M',
                DateTimeOffset.Now.AddYears(-1), 
                DateTimeOffset.Now.Date);

            Paciente Paciente2 = new Paciente(
                50666777,
                "Brandan",
                "Nahiara",
                'F',
                DateTimeOffset.Now.AddYears(-8),
                DateTimeOffset.Now.Date);
            
            return Task.FromResult(new[] { Paciente1, Paciente2 });
        }
    }
} */