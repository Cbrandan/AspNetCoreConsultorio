using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreConsultorio.Models
{
    public class Turno
    {
        public Guid Id { get; set; }
        [Required]
        public int DniPaciente { get; set; }
        [Required]
        public int IdEspecialidad { get; set; }
        [Required]
        public int IdProfesional { get; set; }
        [Required]
        public DateTimeOffset Fecha { get; set; }
        public string Observaciones { get; set; }
        public bool Realizado { get; set; }

/*         public Turno(int pDni, int pEspecialidad, int pProfesional, DateTimeOffset pFecha)
        {
            //Constructor
        } */

    }
}