﻿// <auto-generated />
using System;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(SSDbContext))]
    [Migration("20221119185523_AddedLandlordsTable")]
    partial class AddedLandlordsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Entities.Landlord", b =>
                {
                    b.Property<string>("ProfileUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProfileUID");

                    b.HasIndex("UserUID")
                        .IsUnique();

                    b.ToTable("Landlord", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Role", b =>
                {
                    b.Property<string>("UID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UID");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Student", b =>
                {
                    b.Property<string>("ProfileUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CourseEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CourseStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnrolledCourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversityUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProfileUID");

                    b.HasIndex("UniversityUID")
                        .IsUnique();

                    b.HasIndex("UserUID")
                        .IsUnique();

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.University", b =>
                {
                    b.Property<string>("UID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ratings")
                        .HasColumnType("int");

                    b.Property<string>("UniversityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UID");

                    b.ToTable("University", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Property<string>("UID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UID");

                    b.HasIndex("RoleUID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Landlord", b =>
                {
                    b.HasOne("DataAccess.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("DataAccess.Entities.Landlord", "UserUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Entities.Student", b =>
                {
                    b.HasOne("DataAccess.Entities.University", "University")
                        .WithOne()
                        .HasForeignKey("DataAccess.Entities.Student", "UniversityUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("DataAccess.Entities.Student", "UserUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.HasOne("DataAccess.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
