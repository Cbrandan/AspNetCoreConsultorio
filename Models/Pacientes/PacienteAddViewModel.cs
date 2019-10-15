using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreConsultorio.Models.Sexos;

namespace AspNetCoreConsultorio.Models.Pacientes
{
    public class PacienteAddViewModel
    {
        [Required]
        [Key]
        public int DNI { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public Guid SexoId { get; set; }
        [Required]
        public List<Sexo> Sexos { get; set; }
        [Required]
        public DateTimeOffset Fecha_Nacimiento { get; set; }
        [Required]
        public DateTimeOffset? Fecha_Alta { get; set; }
    }
}
