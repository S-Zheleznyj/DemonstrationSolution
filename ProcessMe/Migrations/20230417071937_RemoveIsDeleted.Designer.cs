﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProcessMe.Data;

#nullable disable

namespace ProcessMe.Migrations
{
    [DbContext(typeof(ProcessMeDbContext))]
    [Migration("20230417071937_RemoveIsDeleted")]
    partial class RemoveIsDeleted
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProcessMe.Models.Entities.Appeal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("ClientEmail")
                        .HasColumnType("text");

                    b.Property<string>("ClientName")
                        .HasColumnType("text");

                    b.Property<string>("ClientPhone")
                        .HasColumnType("text");

                    b.Property<int?>("CommunicationWay")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("EmoloyeeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndProcessDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RecieveDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("StartProcessDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Appeals", (string)null);
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<int>("EmployeesCount")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsBusy")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Employess", (string)null);
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Ratings", (string)null);
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Appeal", b =>
                {
                    b.HasOne("ProcessMe.Models.Entities.Employee", "Employee")
                        .WithMany("Appeals")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Employee", b =>
                {
                    b.HasOne("ProcessMe.Models.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcessMe.Models.Entities.User", "User")
                        .WithMany("Employees")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Rating", b =>
                {
                    b.HasOne("ProcessMe.Models.Entities.Employee", "Employee")
                        .WithMany("Ratings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.User", b =>
                {
                    b.HasOne("ProcessMe.Models.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Employee", b =>
                {
                    b.Navigation("Appeals");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProcessMe.Models.Entities.User", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
