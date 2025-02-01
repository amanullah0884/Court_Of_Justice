﻿// <auto-generated />
using System;
using Court_Of_Justice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Court_Of_Justice.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Court_Of_Justice.Controllers.Models.Adalot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Adalot");
                });

            modelBuilder.Entity("Court_Of_Justice.Controllers.Models.CaseDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CAseMasterID")
                        .HasColumnType("int");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hiering")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HieringDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NextHieringDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CAseMasterID");

                    b.ToTable("CaseDetails");
                });

            modelBuilder.Entity("Court_Of_Justice.Controllers.Models.CaseMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AdalotId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CaseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AdalotId");

                    b.HasIndex("SectionId");

                    b.ToTable("CaseMasters");
                });

            modelBuilder.Entity("Court_Of_Justice.Controllers.Models.CaseSource", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("ID");

                    b.ToTable("CaseSources");
                });

            modelBuilder.Entity("Court_Of_Justice.Controllers.Models.Section", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Court_Of_Justice.Controllers.Models.CaseDetails", b =>
                {
                    b.HasOne("Court_Of_Justice.Controllers.Models.CaseMaster", "CAseMaster")
                        .WithMany()
                        .HasForeignKey("CAseMasterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CAseMaster");
                });

            modelBuilder.Entity("Court_Of_Justice.Controllers.Models.CaseMaster", b =>
                {
                    b.HasOne("Court_Of_Justice.Controllers.Models.Adalot", "Adalot")
                        .WithMany()
                        .HasForeignKey("AdalotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Court_Of_Justice.Controllers.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adalot");

                    b.Navigation("Section");
                });
#pragma warning restore 612, 618
        }
    }
}
