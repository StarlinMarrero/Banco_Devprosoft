using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Models
{
    public class Prestamo
    {
        [Key]
        public int Prestamo_ID { get; set; }
        public string Propietario_ID { get; set; }

        public DateTime Fecha_De_Corte { get; set; }  // Fecha inicial de pago
        public DateTime Fecha_de_Pagos { get; set; }  // Fecha Final de Pago
        public DateTime Fecha_Aprobacion { get; set; }
        public DateTime Fecha_De_Cierre { get; set; }
        public DateTime Fecha_Proyectada { get; set; }  //Fecha aproximada en la que finaliza el préstamo
        public bool Pago_Pendiente { get; set; }

        public int Monto_Aprobado { get; set; }
        public int Monto_Mensual { get; set; } //*****FALTA CONSTANTE DE MORA*******//
        public int Cuotas { get; set; }
        public int Tasa_de_Interes { get; set; }
        public List<Pago> Lista_Pagos { get; set; }

    }

    public class Solicitud_Prestamo : Solicitud
    {
        public int Monto_Solicitado { get; set; }
        public int Plazo_Solicitado { get; set; }
        public bool Aprobado { get; set; }
        public string Aprobado_Por { get; set; }

    }
}
