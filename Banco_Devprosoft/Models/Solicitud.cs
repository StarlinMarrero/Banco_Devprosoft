using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Models
{
    public class Solicitud
    {
        [Key]
        public int Solicitud_ID { get; set; }
        public bool Usuario_Registrado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Contacto_1 { get; set; }
        public string Contacto_2 { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public bool Empleado { get; set; }
        public string Empresa { get; set; }
        public int? Salario { get; set; }
        public string Ocupacion { get; set; }
        public bool Cerrada { get; set; }
        public DateTime Fecha_Cierre { get; set; }
        public DateTime Fecha_Solicitud { get; set; }

    }
}
