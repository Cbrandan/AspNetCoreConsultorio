using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreConsultorio.Data;
using AspNetCoreConsultorio.Models.Sexos;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreConsultorio.Services
{
    public class SexoService : ISexoService
    {
        private readonly ApplicationDbContext _context;

        public SexoService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Sexo>> GetSexosAsync()
        {
            //throw new NotImplementedException();
            return await _context.TablaSexos.ToListAsync();
        }

        public async Task<Sexo> GetSexosByIdAsync(Guid Id)
        {
            //throw new NotImplementedException();
            return await _context.TablaSexos.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
