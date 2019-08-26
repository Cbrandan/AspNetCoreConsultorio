using System;
using System.ComponentModel.DataAnnotations;
namespace AspNetCoreConsultorio.Models
{
public abstract class Persona
{
    public Guid Id { get; set; }
    [Required]
    public int DNI { get; set; }
    public string Apellido { get; set; }
    public string Nombre { get; set; }
    public char Sexo { get; set; }
    public DateTimeOffset Fecha_Nacimiento { get; set; }

       protected Persona(int dni, string apellido, string nombre, char sexo, DateTimeOffset fecha_nacimiento)
    {
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        Sexo = sexo;
        Fecha_Nacimiento = fecha_nacimiento;
    }
}
}