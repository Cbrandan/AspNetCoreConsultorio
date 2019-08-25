using System;
using System.ComponentModel.DataAnnotations;
namespace AspNetCoreConsultorio.Models
{
public class Paciente : Persona
{
    public DateTimeOffset? Fecha_Alta { get; set; }
    public Guid IdPaciente { get; set; }

        public Paciente(int dni, string apellido, string nombre, char sexo, DateTimeOffset? fecha_nacimiento, DateTimeOffset? fecha_alta)
        : base(dni, apellido, nombre, sexo, fecha_nacimiento)
        {
            this.Fecha_Alta = fecha_alta;
        }
    }
}