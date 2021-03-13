using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Models
{
    public class Tarjeta
    {
        [Key]
        public int Tarjeta_ID { get; set; }  // 5
        public string Numero_Tarjeta { get; set; }
        public DateTime Vencimiento { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public string CVC { get; set; }
        public int Cuenta_ID { get; set; }

        [ForeignKey("Cuenta_ID")]
        public Cuenta_Bancaria Get_Bancaria { get; set; }
        public List<Pago> Lista_Pagos { get; set; }
    }
}
