using System;
using System.ComponentModel.DataAnnotations;
namespace AspNetCoreConsultorio.Models
{
/* public class Paciente : Persona
{
    public DateTimeOffset? Fecha_Alta { get; set; }
    
     public Paciente(int dni, string apellido, string nombre, char sexo,
                    DateTimeOffset fecha_nacimiento, DateTimeOffset fecha_alta)
            :base(dni, apellido, nombre, sexo, fecha_nacimiento)
     {
        this.DNI = dni;
        this.Apellido = apellido;
        this.Nombre = nombre;
        this.Sexo = sexo;
        this.Fecha_Nacimiento = fecha_nacimiento;
        this.Fecha_Alta = fecha_alta;
     }
} */
    public class Paciente
    {
        //public Guid Id { get; set; }
        [Required]
        [Key]
        public int DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public char Sexo { get; set; }
        public DateTimeOffset Fecha_Nacimiento { get; set; }
        public DateTimeOffset? Fecha_Alta { get; set; }

/*         public Paciente(int dni, string apellido, string nombre, char sexo, DateTimeOffset fecha_nacimiento, DateTimeOffset fecha_alta)
        {
            this.DNI = dni;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Fecha_Alta = fecha_alta;
        } */

    }
}