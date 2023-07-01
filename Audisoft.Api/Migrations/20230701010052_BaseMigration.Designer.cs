﻿// <auto-generated />
using System;
using Audisoft.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Audisoft.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230701010052_BaseMigration")]
    partial class BaseMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Audisoft.Models.Entities.Notes", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("NUMERIC(20,0)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("StudentId")
                        .HasColumnType("NUMERIC(20,0)");

                    b.Property<decimal>("TeacherId")
                        .HasColumnType("NUMERIC(20,0)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Notes", "Administration");
                });

            modelBuilder.Entity("Audisoft.Models.Entities.Student", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("NUMERIC(20,0)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Students", "Administration");
                });

            modelBuilder.Entity("Audisoft.Models.Entities.Teacher", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("NUMERIC(20,0)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Teachers", "Administration");
                });

            modelBuilder.Entity("Audisoft.Models.Entities.Notes", b =>
                {
                    b.HasOne("Audisoft.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Audisoft.Models.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}