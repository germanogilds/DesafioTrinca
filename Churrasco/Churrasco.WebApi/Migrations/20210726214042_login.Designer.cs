﻿// <auto-generated />
using System;
using Churrasco.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Churrasco.WebApi.Migrations
{
    [DbContext(typeof(EventoChurrascoContext))]
    [Migration("20210726214042_login")]
    partial class login
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Churrasco.Domain.Entities.EventoChurrasco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<decimal>("ValorChurrasco")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("ValorComBebida")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("EventoChurrasco");
                });

            modelBuilder.Entity("Churrasco.Domain.Entities.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChurrascoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDeParticipacao")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValorPago")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.HasIndex("ChurrascoId");

                    b.ToTable("Participante");
                });

            modelBuilder.Entity("Churrasco.Domain.Entities.Participante", b =>
                {
                    b.HasOne("Churrasco.Domain.Entities.EventoChurrasco", "Churrasco")
                        .WithMany("Participantes")
                        .HasForeignKey("ChurrascoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
