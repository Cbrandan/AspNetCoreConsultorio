using AspNetCoreConsultorio.Models.Sexos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreConsultorio.Services
{
    public interface ISexoService
    {
        Task<List<Sexo>> GetSexosAsync();
        Task<Sexo> GetSexosByIdAsync(Guid Id);
    }
}