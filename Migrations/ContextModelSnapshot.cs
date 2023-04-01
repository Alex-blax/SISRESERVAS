﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SISRESERVAS.Data;

#nullable disable

namespace SISRESERVAS.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SISRESERVAS.Models.departamento", b =>
                {
                    b.Property<int>("departamentoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("departamentoid"));

                    b.Property<string>("nombredep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.HasKey("departamentoid");

                    b.ToTable("departamento");
                });

            modelBuilder.Entity("SISRESERVAS.Models.reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("ViajeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("ViajeId");

                    b.ToTable("reserva");
                });

            modelBuilder.Entity("SISRESERVAS.Models.usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("SISRESERVAS.Models.viaje", b =>
                {
                    b.Property<int>("viajeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("viajeid"));

                    b.Property<int>("asientosdis")
                        .HasColumnType("int");

                    b.Property<string>("bus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("conductor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("viajeid");

                    b.ToTable("viaje");
                });

            modelBuilder.Entity("SISRESERVAS.Models.reserva", b =>
                {
                    b.HasOne("SISRESERVAS.Models.departamento", "departamento")
                        .WithMany("reserva")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SISRESERVAS.Models.usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SISRESERVAS.Models.viaje", "viaje")
                        .WithMany("reserva")
                        .HasForeignKey("ViajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("departamento");

                    b.Navigation("usuario");

                    b.Navigation("viaje");
                });

            modelBuilder.Entity("SISRESERVAS.Models.departamento", b =>
                {
                    b.Navigation("reserva");
                });

            modelBuilder.Entity("SISRESERVAS.Models.viaje", b =>
                {
                    b.Navigation("reserva");
                });
#pragma warning restore 612, 618
        }
    }
}
