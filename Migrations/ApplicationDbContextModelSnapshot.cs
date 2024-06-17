﻿// <auto-generated />
using System;
using CenterEnglishManagement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CenterEnglishManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("teacherId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("teacherId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("DateType")
                        .HasColumnType("boolean");

                    b.Property<int>("IdClass")
                        .HasColumnType("integer");

                    b.Property<int>("NumOfSession")
                        .HasColumnType("integer");

                    b.Property<int>("Shift")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.StudentAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("boolean");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAttendances");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.TuitionFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TuitionFees");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.UserModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.UserModels.Admin", b =>
                {
                    b.HasBaseType("CenterEnglishManagement.Models.UserModels.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.UserModels.Parent", b =>
                {
                    b.HasBaseType("CenterEnglishManagement.Models.UserModels.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Users", t =>
                        {
                            t.Property("Address")
                                .HasColumnName("Parent_Address");

                            t.Property("Mobile")
                                .HasColumnName("Parent_Mobile");
                        });

                    b.HasDiscriminator().HasValue("Parent");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.UserModels.Student", b =>
                {
                    b.HasBaseType("CenterEnglishManagement.Models.UserModels.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ParentId")
                        .HasColumnType("integer");

                    b.HasIndex("ClassId");

                    b.HasIndex("ParentId");

                    b.ToTable("Users", t =>
                        {
                            t.Property("Address")
                                .HasColumnName("Student_Address");

                            t.Property("DOB")
                                .HasColumnName("Student_DOB");

                            t.Property("Gender")
                                .HasColumnName("Student_Gender");

                            t.Property("IsActive")
                                .HasColumnName("Student_IsActive");

                            t.Property("Mobile")
                                .HasColumnName("Student_Mobile");
                        });

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.UserModels.Teacher", b =>
                {
                    b.HasBaseType("CenterEnglishManagement.Models.UserModels.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("Mobile")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.Class", b =>
                {
                    b.HasOne("CenterEnglishManagement.Models.UserModels.Teacher", null)
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.Payment", b =>
                {
                    b.HasOne("CenterEnglishManagement.Models.UserModels.Student", null)
                        .WithMany("Payments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.Salary", b =>
                {
                    b.HasOne("CenterEnglishManagement.Models.UserModels.Teacher", null)
                        .WithMany("Salaries")
                        .HasForeignKey("teacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.StudentAttendance", b =>
                {
                    b.HasOne("CenterEnglishManagement.Models.UserModels.Student", null)
                        .WithMany("StudentAttendances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.UserModels.Student", b =>
                {
                    b.HasOne("CenterEnglishManagement.Models.OtherModels.Class", null)
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CenterEnglishManagement.Models.UserModels.Parent", null)
                        .WithMany("Students")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.OtherModels.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.UserModels.Parent", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.UserModels.Student", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("StudentAttendances");
                });

            modelBuilder.Entity("CenterEnglishManagement.Models.UserModels.Teacher", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Salaries");
                });
#pragma warning restore 612, 618
        }
    }
}
