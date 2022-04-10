﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Slitherlink.SlitherlinkCore.SlitherlinkService;

#nullable disable

namespace Slitherlink.Migrations
{
    [DbContext(typeof(SlitherlinkDbContext))]
    [Migration("20220409174935_Mig1")]
    partial class Mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Slitherlink.SlitherlinkCore.SlitherlinkEntity.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Slitherlink.SlitherlinkCore.SlitherlinkEntity.Hodnotenie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Meno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("stars")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Hodnotenies");
                });

            modelBuilder.Entity("Slitherlink.SlitherlinkCore.SlitherlinkEntity.Score", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Player")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
