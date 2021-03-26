using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_Devprosoft.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public bool Trabaja { get; set; }
        public string Contacto_1 { get; set; }
        public string Contacto_2 { get; set; }
        public string Ocupacion { get; set; }
        public string Empresa { get; set; }
        public int? Sueldo { get; set; }

    }
}
