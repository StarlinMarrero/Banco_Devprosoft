using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Models
{
    public class Cuenta_Bancaria
    {
        [Key]
        public int Cuenta_ID  { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public int Balance { get; set; }
        public bool Cerrada { get; set; }
        public DateTime? Fecha_Cierre { get; set; }
        public string Propietario_ID { get; set; }

        [ForeignKey("Propietario_ID")]
        public ApplicationUser Get_Propietario { get; set; }

    }


}
