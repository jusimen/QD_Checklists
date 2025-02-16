﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QD_Checklists.DbContexts;

#nullable disable

namespace QD_Checklists.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240916094405_ChecklistDtoDecortors")]
    partial class ChecklistDtoDecortors
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("QD_Checklists.DTOs.AreaDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.ChecklistDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ApproverId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AreaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CheckerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComponentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DivisionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Order")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RegionCountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Regulations")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamLeaderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypologyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("AreaId");

                    b.HasIndex("CheckerId");

                    b.HasIndex("ClientManagerId");

                    b.HasIndex("ComponentId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("PhaseId");

                    b.HasIndex("ProjectManagerId");

                    b.HasIndex("RegionCountryId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("TeamLeaderId");

                    b.HasIndex("TypologyId");

                    b.ToTable("Checklists");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.ChecklistTaskDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChecklistDTOId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChecklistTaskDTOId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Order")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChecklistDTOId");

                    b.HasIndex("ChecklistTaskDTOId");

                    b.ToTable("ChecklistTasks");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.ComponentDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.DivisionDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.PhaseDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.RegionDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.RoleDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.TypologyDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Typologies");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.UserDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.ChecklistDTO", b =>
                {
                    b.HasOne("QD_Checklists.DTOs.UserDTO", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId");

                    b.HasOne("QD_Checklists.DTOs.AreaDTO", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QD_Checklists.DTOs.UserDTO", "Checker")
                        .WithMany()
                        .HasForeignKey("CheckerId");

                    b.HasOne("QD_Checklists.DTOs.UserDTO", "ClientManager")
                        .WithMany()
                        .HasForeignKey("ClientManagerId");

                    b.HasOne("QD_Checklists.DTOs.ComponentDTO", "Component")
                        .WithMany()
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QD_Checklists.DTOs.DivisionDTO", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QD_Checklists.DTOs.PhaseDTO", "Phase")
                        .WithMany()
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QD_Checklists.DTOs.UserDTO", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QD_Checklists.DTOs.RegionDTO", "RegionCountry")
                        .WithMany()
                        .HasForeignKey("RegionCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QD_Checklists.DTOs.UserDTO", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QD_Checklists.DTOs.UserDTO", "TeamLeader")
                        .WithMany()
                        .HasForeignKey("TeamLeaderId");

                    b.HasOne("QD_Checklists.DTOs.TypologyDTO", "Typology")
                        .WithMany()
                        .HasForeignKey("TypologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("Area");

                    b.Navigation("Checker");

                    b.Navigation("ClientManager");

                    b.Navigation("Component");

                    b.Navigation("Division");

                    b.Navigation("Phase");

                    b.Navigation("ProjectManager");

                    b.Navigation("RegionCountry");

                    b.Navigation("Reviewer");

                    b.Navigation("TeamLeader");

                    b.Navigation("Typology");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.ChecklistTaskDTO", b =>
                {
                    b.HasOne("QD_Checklists.DTOs.ChecklistDTO", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ChecklistDTOId");

                    b.HasOne("QD_Checklists.DTOs.ChecklistTaskDTO", null)
                        .WithMany("SubTasks")
                        .HasForeignKey("ChecklistTaskDTOId");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.UserDTO", b =>
                {
                    b.HasOne("QD_Checklists.DTOs.RoleDTO", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.ChecklistDTO", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("QD_Checklists.DTOs.ChecklistTaskDTO", b =>
                {
                    b.Navigation("SubTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
