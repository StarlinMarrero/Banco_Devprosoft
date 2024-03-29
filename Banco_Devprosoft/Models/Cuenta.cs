﻿using System;
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
        public string Tipo_Cuenta { get; set; } //Ahorro, Credito, Prestamo, etc
        public DateTime Fecha_Creacion { get; set; }
        public int Balance { get; set; }
        public bool Cerrada { get; set; }
        public int Monto_Maximo { get; set; }
        public DateTime Fecha_De_Corte { get; set; }
        public DateTime Fecha_Limite { get; set; }
        public DateTime? Fecha_Cierre { get; set; }
        public string Propietario_ID { get; set; }

        [ForeignKey("Propietario_ID")]
        public ApplicationUser Get_Propietario { get; set; }
    }

    public class Solicitud_Cuenta : Solicitud
    {
        public string Tipo_De_Cuenta { get; set; }

    }



}
