﻿// <auto-generated />
using System;
using MeowSanctuary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeowSanctuary.Migrations
{
    [DbContext(typeof(SanctuaryContext))]
    partial class SanctuaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeowSanctuary.Models.Cat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ShelterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("MeowSanctuary.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("MeowSanctuary.Models.Shelter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shelters");
                });

            modelBuilder.Entity("MeowSanctuary.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MeowSanctuary.Models.WorkSchedule", b =>
                {
                    b.Property<Guid>("WorkerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CatId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WorkerId", "CatId");

                    b.HasIndex("CatId");

                    b.ToTable("WorkSchedules");
                });

            modelBuilder.Entity("MeowSanctuary.Models.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("MeowSanctuary.Models.Cat", b =>
                {
                    b.HasOne("MeowSanctuary.Models.Shelter", "Shelter")
                        .WithMany("Cats")
                        .HasForeignKey("ShelterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("MeowSanctuary.Models.User", b =>
                {
                    b.HasOne("MeowSanctuary.Models.Worker", "Worker")
                        .WithOne("User")
                        .HasForeignKey("MeowSanctuary.Models.User", "WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("MeowSanctuary.Models.WorkSchedule", b =>
                {
                    b.HasOne("MeowSanctuary.Models.Cat", "Cat")
                        .WithMany("WorkSchedules")
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeowSanctuary.Models.Worker", "Worker")
                        .WithMany("WorkSchedules")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cat");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("MeowSanctuary.Models.Worker", b =>
                {
                    b.HasOne("MeowSanctuary.Models.Job", "Job")
                        .WithMany("Workers")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("MeowSanctuary.Models.Cat", b =>
                {
                    b.Navigation("WorkSchedules");
                });

            modelBuilder.Entity("MeowSanctuary.Models.Job", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("MeowSanctuary.Models.Shelter", b =>
                {
                    b.Navigation("Cats");
                });

            modelBuilder.Entity("MeowSanctuary.Models.Worker", b =>
                {
                    b.Navigation("User")
                        .IsRequired();

                    b.Navigation("WorkSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
