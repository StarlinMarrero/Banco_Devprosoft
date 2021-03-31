﻿// <auto-generated />
using System;
using Banco_Devprosoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Banco_Devprosoft.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210331122704_Salario_A_String")]
    partial class Salario_A_String
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Banco_Devprosoft.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacto_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacto_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Ocupacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sueldo")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Trabaja")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Cuenta_Bancaria", b =>
                {
                    b.Property<int>("Cuenta_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<bool>("Cerrada")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Fecha_Cierre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_De_Corte")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Limite")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto_Maximo")
                        .HasColumnType("int");

                    b.Property<string>("Propietario_ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tipo_Cuenta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cuenta_ID");

                    b.HasIndex("Propietario_ID");

                    b.ToTable("Cuentas_Bancarias");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Pago", b =>
                {
                    b.Property<int>("Pago_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cuenta_Destino_ID")
                        .HasColumnType("int");

                    b.Property<int>("Cuenta_Origen_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Pago")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto_Parcial")
                        .HasColumnType("int");

                    b.Property<int>("Monto_Total")
                        .HasColumnType("int");

                    b.Property<int>("Mora")
                        .HasColumnType("int");

                    b.Property<int?>("Prestamo_ID")
                        .HasColumnType("int");

                    b.Property<string>("Servicio_Pagado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pago_ID");

                    b.HasIndex("Prestamo_ID");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Prestamo", b =>
                {
                    b.Property<int>("Prestamo_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cuotas")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Aprobacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_De_Cierre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_De_Corte")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Proyectada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_de_Pagos")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto_Aprobado")
                        .HasColumnType("int");

                    b.Property<int>("Monto_Mensual")
                        .HasColumnType("int");

                    b.Property<bool>("Pago_Pendiente")
                        .HasColumnType("bit");

                    b.Property<string>("Propietario_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tasa_de_Interes")
                        .HasColumnType("int");

                    b.HasKey("Prestamo_ID");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Solicitud_Cuenta", b =>
                {
                    b.Property<int>("Solicitud_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cerrada")
                        .HasColumnType("bit");

                    b.Property<string>("Contacto_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacto_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Empleado")
                        .HasColumnType("bit");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Cierre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Solicitud")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ocupacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_Cuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_De_Cuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Usuario_Registrado")
                        .HasColumnType("bit");

                    b.HasKey("Solicitud_ID");

                    b.ToTable("Solicitudes_Cuentas");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Solicitud_Prestamo", b =>
                {
                    b.Property<int>("Solicitud_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aprobado")
                        .HasColumnType("bit");

                    b.Property<string>("Aprobado_Por")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cerrada")
                        .HasColumnType("bit");

                    b.Property<string>("Contacto_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacto_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Empleado")
                        .HasColumnType("bit");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Cierre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Solicitud")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto_Solicitado")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ocupacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Plazo_Solicitado")
                        .HasColumnType("int");

                    b.Property<string>("Salario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_Cuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Usuario_Registrado")
                        .HasColumnType("bit");

                    b.HasKey("Solicitud_ID");

                    b.ToTable("Solicitudes_Prestamos");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Tarjeta", b =>
                {
                    b.Property<int>("Tarjeta_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cuenta_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Emision")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero_Tarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Vencimiento")
                        .HasColumnType("datetime2");

                    b.HasKey("Tarjeta_ID");

                    b.HasIndex("Cuenta_ID");

                    b.ToTable("Tarjetas");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Transferencia", b =>
                {
                    b.Property<int>("Transferencia_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cuenta_Destino_ID")
                        .HasColumnType("int");

                    b.Property<int>("Cuenta_Origen_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Transaccion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.HasKey("Transferencia_ID");

                    b.HasIndex("Cuenta_Origen_ID");

                    b.ToTable("Transferencias");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Cuenta_Bancaria", b =>
                {
                    b.HasOne("Banco_Devprosoft.Models.ApplicationUser", "Get_Propietario")
                        .WithMany()
                        .HasForeignKey("Propietario_ID");

                    b.Navigation("Get_Propietario");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Pago", b =>
                {
                    b.HasOne("Banco_Devprosoft.Models.Prestamo", null)
                        .WithMany("Lista_Pagos")
                        .HasForeignKey("Prestamo_ID");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Tarjeta", b =>
                {
                    b.HasOne("Banco_Devprosoft.Models.Cuenta_Bancaria", "Get_Bancaria")
                        .WithMany()
                        .HasForeignKey("Cuenta_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Get_Bancaria");
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Transferencia", b =>
                {
                    b.HasOne("Banco_Devprosoft.Models.Cuenta_Bancaria", "Get_Cuenta_Origen")
                        .WithMany()
                        .HasForeignKey("Cuenta_Origen_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Get_Cuenta_Origen");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Banco_Devprosoft.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Banco_Devprosoft.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Banco_Devprosoft.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Banco_Devprosoft.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Banco_Devprosoft.Models.Prestamo", b =>
                {
                    b.Navigation("Lista_Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}