﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioProjets.API.Data;

#nullable disable

namespace PortfolioProjets.API.Migrations
{
    [DbContext(typeof(ProjetsContext))]
    partial class ProjetsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("PortfolioProjets.API.Models.Projet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlCodeSource")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projets");
                });
#pragma warning restore 612, 618
        }
    }
}
