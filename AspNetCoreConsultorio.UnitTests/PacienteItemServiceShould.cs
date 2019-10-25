using AspNetCoreConsultorio.Data;
using AspNetCoreConsultorio.Models;
using AspNetCoreConsultorio.Models.Sexos;
using AspNetCoreConsultorio.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreConsultorio.UnitTests
{
    public class PacienteItemServiceShould
    {
        [Fact]
        public async Task AddNewItemWithDischargeDate()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddNewItemPaciente").Options;

            using (var context = new ApplicationDbContext(options))
            {
                var serviceTableSexos = new SexoService(context);
                var tablaSexo = new Sexo
                {
                    Id = new Guid(),
                    Name = "Masculino"
                };
                var servicePaciente = new PacienteItemService(context, serviceTableSexos);
                var fakeUser = new IdentityUser
                {
                    Id = "fake-000",
                    UserName = "fake@example.com"
                };

                await servicePaciente.AddPacienteAsync(new Paciente
                {
                    DNI = 30555333,
                    Apellido = "Fulanito",
                    Nombre = "Cosme",
                    Sexo = serviceTableSexos.GetSexosByIdAsync(tablaSexo.Id).Result,
                    Fecha_Nacimiento = DateTime.Now.AddYears(-20)
                }, fakeUser);
            }

            using (var context = new ApplicationDbContext(options))
            {
                var itemsInDatabase = await context.Pacientes.CountAsync();
                Assert.Equal(1, itemsInDatabase);
                var item = await context.Pacientes.FirstAsync();
                Assert.Equal(30555333, item.DNI);
                Assert.Equal("Fulanito", item.Apellido);
                Assert.Equal("Cosme", item.Nombre);
                Assert.Equal("Masculino", item.Sexo.Name);
                // Item should be due 3 days from now (give or take a second)
                var edad = DateTimeOffset.Now - item.Fecha_Nacimiento;

            }
        }
    }
}
