﻿// <auto-generated />
using System;
using Cobranca.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cobranca.InfraStructure.Migrations
{
    [DbContext(typeof(CobrancaContext))]
    [Migration("20240218125142_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cobranca.Domain.Entities.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("PercJuros")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("Cobranca.Domain.Entities.Boleto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BancoId")
                        .HasColumnType("integer");

                    b.Property<string>("CpfCnpjBeneficiario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CpfCnpjPagador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NomeBeneficiario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomePagador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Boletos");
                });

            modelBuilder.Entity("Cobranca.Domain.Entities.Boleto", b =>
                {
                    b.HasOne("Cobranca.Domain.Entities.Banco", "Banco")
                        .WithMany("ListBoleto")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });

            modelBuilder.Entity("Cobranca.Domain.Entities.Banco", b =>
                {
                    b.Navigation("ListBoleto");
                });
#pragma warning restore 612, 618
        }
    }
}
