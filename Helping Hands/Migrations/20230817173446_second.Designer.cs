﻿// <auto-generated />
using System;
using Helping_Hands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Helping_Hands.Migrations
{
    [DbContext(typeof(GRP0452HelpingHandsDBContext))]
    [Migration("20230817173446_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Helping_Hands.Admins", b =>
                {
                    b.Property<int>("AdminUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminContact")
                        .HasColumnType("int");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdNumber")
                        .HasColumnType("int");

                    b.Property<string>("LineAddress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuburbID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminUserID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Helping_Hands.CareContracts", b =>
                {
                    b.Property<int>("ContractNumberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ContractDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("NurseUserID")
                        .HasColumnType("int");

                    b.Property<int>("PatientUserID")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuburbID")
                        .HasColumnType("int");

                    b.Property<string>("WoundDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContractNumberID");

                    b.HasIndex("CityID");

                    b.HasIndex("NurseUserID");

                    b.HasIndex("PatientUserID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("SuburbID");

                    b.ToTable("CareContracts");
                });

            modelBuilder.Entity("Helping_Hands.CareVisits", b =>
                {
                    b.Property<int>("CareVisitsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("ApproxArriva")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("ArrivalTime")
                        .HasColumnType("time");

                    b.Property<int>("ContractNumberID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("DepartTime")
                        .HasColumnType("time");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NurseUserID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WoundCondition")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CareVisitsID");

                    b.HasIndex("ContractNumberID");

                    b.HasIndex("NurseUserID");

                    b.ToTable("CareVisits");
                });

            modelBuilder.Entity("Helping_Hands.ChronicAccoms", b =>
                {
                    b.Property<int>("ChronicAccomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChronicID")
                        .HasColumnType("int");

                    b.Property<int?>("PatientUserID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChronicAccomID");

                    b.HasIndex("ChronicID");

                    b.HasIndex("PatientUserID");

                    b.ToTable("ChronicAccoms");
                });

            modelBuilder.Entity("Helping_Hands.ChronicInfections", b =>
                {
                    b.Property<int>("ChronicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConditionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChronicID");

                    b.ToTable("ChronicInfections");
                });

            modelBuilder.Entity("Helping_Hands.Cities", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbrev")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.HasIndex("ProvinceID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Helping_Hands.Data.UserApp", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Helping_Hands.ImageArchive", b =>
                {
                    b.Property<int>("ImageArchiveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("NpoID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageArchiveID");

                    b.HasIndex("NpoID");

                    b.ToTable("ImageArchive");
                });

            modelBuilder.Entity("Helping_Hands.Managers", b =>
                {
                    b.Property<int>("ManagerUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdNumber")
                        .HasColumnType("int");

                    b.Property<string>("LineAddress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NpoID")
                        .HasColumnType("int");

                    b.Property<int?>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuburbID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManagerUserID");

                    b.HasIndex("CityID");

                    b.HasIndex("NpoID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("SuburbID");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Helping_Hands.Models.Patients", b =>
                {
                    b.Property<int>("PatientUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInfor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("IdNumber")
                        .HasColumnType("float");

                    b.Property<string>("LineAddress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextOfKinContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextOfKinName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuburbID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientUserID");

                    b.HasIndex("CityID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("SuburbID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Helping_Hands.Nurses", b =>
                {
                    b.Property<int>("NurseUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("IdNumber")
                        .HasColumnType("float");

                    b.Property<string>("LineAddress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NurseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NurseContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuburbID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NurseUserID");

                    b.ToTable("Nurses");
                });

            modelBuilder.Entity("Helping_Hands.Organisations", b =>
                {
                    b.Property<int>("NpoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("ClosingTime")
                        .HasColumnType("time");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineAddress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NpoNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("OpeningTime")
                        .HasColumnType("time");

                    b.Property<string>("OrganisationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuburbID")
                        .HasColumnType("int");

                    b.Property<string>("WeekDay1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeekDay2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NpoID");

                    b.HasIndex("CityID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("SuburbID");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("Helping_Hands.PreferedSuburbs", b =>
                {
                    b.Property<int>("PreferedSubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<int?>("NurseUserID")
                        .HasColumnType("int");

                    b.Property<int?>("SuburbID")
                        .HasColumnType("int");

                    b.HasKey("PreferedSubID");

                    b.HasIndex("CityID");

                    b.HasIndex("NurseUserID");

                    b.HasIndex("SuburbID");

                    b.ToTable("PreferedSuburbs");
                });

            modelBuilder.Entity("Helping_Hands.Provinces", b =>
                {
                    b.Property<int>("ProvinceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceID");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Helping_Hands.Suburbs", b =>
                {
                    b.Property<int>("SuburbID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuburbID");

                    b.HasIndex("CityID");

                    b.ToTable("Suburbs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Helping_Hands.CareContracts", b =>
                {
                    b.HasOne("Helping_Hands.Cities", "City")
                        .WithMany("CareContracts")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Helping_Hands.Nurses", "NurseUser")
                        .WithMany("CareContracts")
                        .HasForeignKey("NurseUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Helping_Hands.Models.Patients", "PatientUser")
                        .WithMany("CareContracts")
                        .HasForeignKey("PatientUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Helping_Hands.Provinces", "Province")
                        .WithMany("CareContracts")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Helping_Hands.Suburbs", "Suburb")
                        .WithMany("CareContracts")
                        .HasForeignKey("SuburbID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Helping_Hands.CareVisits", b =>
                {
                    b.HasOne("Helping_Hands.CareContracts", "ContractNumber")
                        .WithMany("CareVisits")
                        .HasForeignKey("ContractNumberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Helping_Hands.Nurses", "NurseUser")
                        .WithMany("CareVisits")
                        .HasForeignKey("NurseUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Helping_Hands.ChronicAccoms", b =>
                {
                    b.HasOne("Helping_Hands.ChronicInfections", "Chronic")
                        .WithMany("ChronicAccoms")
                        .HasForeignKey("ChronicID");

                    b.HasOne("Helping_Hands.Models.Patients", "PatientUser")
                        .WithMany("ChronicAccoms")
                        .HasForeignKey("PatientUserID");
                });

            modelBuilder.Entity("Helping_Hands.Cities", b =>
                {
                    b.HasOne("Helping_Hands.Provinces", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Helping_Hands.ImageArchive", b =>
                {
                    b.HasOne("Helping_Hands.Organisations", "Npo")
                        .WithMany("ImageArchive")
                        .HasForeignKey("NpoID");
                });

            modelBuilder.Entity("Helping_Hands.Managers", b =>
                {
                    b.HasOne("Helping_Hands.Cities", "City")
                        .WithMany("Managers")
                        .HasForeignKey("CityID");

                    b.HasOne("Helping_Hands.Organisations", "Npo")
                        .WithMany("Managers")
                        .HasForeignKey("NpoID");

                    b.HasOne("Helping_Hands.Provinces", "Province")
                        .WithMany("Managers")
                        .HasForeignKey("ProvinceID");

                    b.HasOne("Helping_Hands.Suburbs", "Suburb")
                        .WithMany("Managers")
                        .HasForeignKey("SuburbID");
                });

            modelBuilder.Entity("Helping_Hands.Models.Patients", b =>
                {
                    b.HasOne("Helping_Hands.Cities", "City")
                        .WithMany("Patients")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade);


                    b.HasOne("Helping_Hands.Provinces", "Province")
                        .WithMany("Patients")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade);


                    b.HasOne("Helping_Hands.Suburbs", "Suburb")
                        .WithMany("Patients")
                        .HasForeignKey("SuburbID")
                        .OnDelete(DeleteBehavior.Cascade);
                        
                });

            modelBuilder.Entity("Helping_Hands.Organisations", b =>
                {
                    b.HasOne("Helping_Hands.Cities", "City")
                        .WithMany("Organisations")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Helping_Hands.Provinces", "Province")
                        .WithMany("Organisations")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Helping_Hands.Suburbs", "Suburb")
                        .WithMany("Organisations")
                        .HasForeignKey("SuburbID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Helping_Hands.PreferedSuburbs", b =>
                {
                    b.HasOne("Helping_Hands.Cities", "City")
                        .WithMany("PreferedSuburbs")
                        .HasForeignKey("CityID");

                    b.HasOne("Helping_Hands.Nurses", "NurseUser")
                        .WithMany("PreferedSuburbs")
                        .HasForeignKey("NurseUserID");

                    b.HasOne("Helping_Hands.Suburbs", "Suburb")
                        .WithMany("PreferedSuburbs")
                        .HasForeignKey("SuburbID");
                });

            modelBuilder.Entity("Helping_Hands.Suburbs", b =>
                {
                    b.HasOne("Helping_Hands.Cities", "City")
                        .WithMany("Suburbs")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Helping_Hands.Data.UserApp", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Helping_Hands.Data.UserApp", null)
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

                    b.HasOne("Helping_Hands.Data.UserApp", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Helping_Hands.Data.UserApp", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
