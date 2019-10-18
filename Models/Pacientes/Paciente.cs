using AspNetCoreConsultorio.Models.Sexos;
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
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public virtual Sexo Sexo { get; set; }
        [Required]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required]
        public DateTime? Fecha_Alta { get; set; }
        [Required]
        public string UserId { get; set; }


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