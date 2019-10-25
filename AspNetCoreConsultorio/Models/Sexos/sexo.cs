using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreConsultorio.Models.Sexos
{
    public class Sexo
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Código de sexo {0} es requerido")]
        [StringLength(8)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
