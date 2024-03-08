﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using programmeringmed.NetProjekt.Data;

#nullable disable

namespace programmeringmed.NetProjekt.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240306153706_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Admin")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.BodyPartModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BodyPart")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BodyPart");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ConditionFormModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConditionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ConditionForm");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ConditionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConditionFormId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConditionTypeId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ConditionFormId");

                    b.HasIndex("ConditionTypeId");

                    b.HasIndex("WorkoutId")
                        .IsUnique();

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ConditionTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConditionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ConditionType");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.DisciplineModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisciplineName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Discipline");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ExerciseFormModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExerciseForm")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExerciseForm");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ExerciseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BodyPartId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BodyPartId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.MethodModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Method");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.OrganizationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.SkiingFocusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FocusName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SkiingFocus");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.SkiingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ApproachToTask")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompletedRuns")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DisciplineId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FocusId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Freeruns")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GateDistance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Goal")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MethodId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Runs")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TurnsPerRun")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("FocusId");

                    b.HasIndex("MethodId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("WorkoutId")
                        .IsUnique();

                    b.ToTable("Skiing");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.WorkoutExerciseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutExercise");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.WorkoutModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BodyPartId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConditionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ExerciseFormId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SkiingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BodyPartId");

                    b.HasIndex("ExerciseFormId");

                    b.ToTable("Workout");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("programmeringmed.NetProjekt.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("programmeringmed.NetProjekt.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("programmeringmed.NetProjekt.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("programmeringmed.NetProjekt.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ConditionModel", b =>
                {
                    b.HasOne("programmeringmed.NetProjekt.Models.ConditionFormModel", "ConditionForm")
                        .WithMany("Condition")
                        .HasForeignKey("ConditionFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("programmeringmed.NetProjekt.Models.ConditionTypeModel", "ConditionType")
                        .WithMany("Condition")
                        .HasForeignKey("ConditionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("programmeringmed.NetProjekt.Models.WorkoutModel", "Workout")
                        .WithOne("Condition")
                        .HasForeignKey("programmeringmed.NetProjekt.Models.ConditionModel", "WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ConditionForm");

                    b.Navigation("ConditionType");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ExerciseModel", b =>
                {
                    b.HasOne("programmeringmed.NetProjekt.Models.BodyPartModel", "BodyPart")
                        .WithMany("Exercise")
                        .HasForeignKey("BodyPartId");

                    b.Navigation("BodyPart");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.SkiingModel", b =>
                {
                    b.HasOne("programmeringmed.NetProjekt.Models.DisciplineModel", "Discipline")
                        .WithMany("Skiing")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("programmeringmed.NetProjekt.Models.SkiingFocusModel", "Focus")
                        .WithMany("Skiing")
                        .HasForeignKey("FocusId");

                    b.HasOne("programmeringmed.NetProjekt.Models.MethodModel", "Method")
                        .WithMany("Skiing")
                        .HasForeignKey("MethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("programmeringmed.NetProjekt.Models.OrganizationModel", "Organization")
                        .WithMany("Skiing")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("programmeringmed.NetProjekt.Models.WorkoutModel", "Workout")
                        .WithOne("Skiing")
                        .HasForeignKey("programmeringmed.NetProjekt.Models.SkiingModel", "WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Discipline");

                    b.Navigation("Focus");

                    b.Navigation("Method");

                    b.Navigation("Organization");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.WorkoutExerciseModel", b =>
                {
                    b.HasOne("programmeringmed.NetProjekt.Models.ExerciseModel", "Exercise")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("ExerciseId");

                    b.HasOne("programmeringmed.NetProjekt.Models.WorkoutModel", "Workout")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.WorkoutModel", b =>
                {
                    b.HasOne("programmeringmed.NetProjekt.Models.BodyPartModel", "BodyPart")
                        .WithMany("Workout")
                        .HasForeignKey("BodyPartId");

                    b.HasOne("programmeringmed.NetProjekt.Models.ExerciseFormModel", "ExerciseForm")
                        .WithMany("Workout")
                        .HasForeignKey("ExerciseFormId");

                    b.Navigation("BodyPart");

                    b.Navigation("ExerciseForm");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.BodyPartModel", b =>
                {
                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ConditionFormModel", b =>
                {
                    b.Navigation("Condition");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ConditionTypeModel", b =>
                {
                    b.Navigation("Condition");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.DisciplineModel", b =>
                {
                    b.Navigation("Skiing");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ExerciseFormModel", b =>
                {
                    b.Navigation("Workout");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.ExerciseModel", b =>
                {
                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.MethodModel", b =>
                {
                    b.Navigation("Skiing");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.OrganizationModel", b =>
                {
                    b.Navigation("Skiing");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.SkiingFocusModel", b =>
                {
                    b.Navigation("Skiing");
                });

            modelBuilder.Entity("programmeringmed.NetProjekt.Models.WorkoutModel", b =>
                {
                    b.Navigation("Condition");

                    b.Navigation("Skiing");

                    b.Navigation("WorkoutExercises");
                });
#pragma warning restore 612, 618
        }
    }
}