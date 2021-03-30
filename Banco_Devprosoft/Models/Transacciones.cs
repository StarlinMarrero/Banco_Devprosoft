using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Models
{
    public class Transferencia
    {
        [Key]
        public int Transferencia_ID { get; set; }
        public int Cuenta_Origen_ID { get; set; }
        public int Cuenta_Destino_ID { get; set; }
        public DateTime Fecha_Transaccion { get; set; }
        public int Monto { get; set; } //*****FALTA CONSTANTE DE IMPUESTOS (GANANCIA DEL BANCO)*******//

        [ForeignKey("Cuenta_Origen_ID")]
        public Cuenta_Bancaria Get_Cuenta_Origen { get; set; }

    }

    public class Pago
    {
        [Key]
        public int Pago_ID { get; set; }
        public string Servicio_Pagado { get; set; }
        public int Cuenta_Origen_ID { get; set; }
        public int Monto_Parcial { get; set; }
        public int Mora { get; set; }
        public int Monto_Total { get; set; }
        public DateTime Fecha_Pago { get; set; }
        //public int Servicio_ID { get; set; }
        //[ForeignKey("Servicio_ID")]
        //public Prestamo Get_Prestamo { get; set; }

        //[ForeignKey("Servicio_ID")]
        //public Tarjeta Get_Tarjeta { get; set; }


    }


}
