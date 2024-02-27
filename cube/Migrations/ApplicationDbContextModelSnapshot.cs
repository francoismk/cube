﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cube;

#nullable disable

namespace cube.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cube.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("EmployeeBirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmployeeFirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("cube.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ZipCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("cube.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ServiceId"));

                    b.Property<int?>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ServiceId");

                    b.HasIndex("LocationId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("cube.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserFirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("cube.Employee", b =>
                {
                    b.HasOne("cube.Service", "Service")
                        .WithMany("Employees")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("cube.Service", b =>
                {
                    b.HasOne("cube.Location", null)
                        .WithMany("Services")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("cube.Location", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("cube.Service", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}