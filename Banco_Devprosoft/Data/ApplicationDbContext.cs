using Banco_Devprosoft.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco_Devprosoft.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cuenta_Bancaria> Cuentas_Bancarias { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Solicitud_Prestamo> Solicitudes_Prestamos { get; set; }
        public DbSet<Solicitud_Cuenta> Solicitudes_Cuentas { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }


    }
}
