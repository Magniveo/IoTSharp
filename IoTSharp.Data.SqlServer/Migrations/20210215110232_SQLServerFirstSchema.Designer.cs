﻿// <auto-generated />
using System;
using IoTSharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IoTSharp.Data.SqlServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210215110232_SQLServerFirstSchema")]
    partial class SQLServerFirstSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IoTSharp.Data.AuditLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActionData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActionResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ActiveDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ObjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ObjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjectType")
                        .HasColumnType("int");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TenantId");

                    b.ToTable("AuditLog");
                });

            modelBuilder.Entity("IoTSharp.Data.AuthorizedKey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TenantId");

                    b.ToTable("AuthorizedKeys");
                });

            modelBuilder.Entity("IoTSharp.Data.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("IoTSharp.Data.DataStorage", b =>
                {
                    b.Property<int>("Catalog")
                        .HasColumnType("int");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KeyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DataSide")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<byte[]>("Value_Binary")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Value_Boolean")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Value_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value_Double")
                        .HasColumnType("float");

                    b.Property<string>("Value_Json")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Value_Long")
                        .HasColumnType("bigint");

                    b.Property<string>("Value_String")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value_XML")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Catalog", "DeviceId", "KeyName");

                    b.HasIndex("Catalog");

                    b.HasIndex("Catalog", "DeviceId");

                    b.ToTable("DataStorage");

                    b.HasDiscriminator<int>("Catalog").HasValue(0);
                });

            modelBuilder.Entity("IoTSharp.Data.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorizedKeyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DeviceType")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Online")
                        .HasColumnType("bit");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Timeout")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorizedKeyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TenantId");

                    b.ToTable("Device");

                    b.HasDiscriminator<int>("DeviceType").HasValue(0);
                });

            modelBuilder.Entity("IoTSharp.Data.DeviceIdentity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdentityType")
                        .HasColumnType("int");

                    b.Property<string>("IdentityValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("DeviceIdentities");
                });

            modelBuilder.Entity("IoTSharp.Data.Relationship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("IdentityUserId");

                    b.HasIndex("TenantId");

                    b.ToTable("Relationship");
                });

            modelBuilder.Entity("IoTSharp.Data.TelemetryData", b =>
                {
                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KeyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DataSide")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<byte[]>("Value_Binary")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Value_Boolean")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Value_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value_Double")
                        .HasColumnType("float");

                    b.Property<string>("Value_Json")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Value_Long")
                        .HasColumnType("bigint");

                    b.Property<string>("Value_String")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value_XML")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeviceId", "KeyName", "DateTime");

                    b.HasIndex("DeviceId");

                    b.HasIndex("KeyName");

                    b.HasIndex("DeviceId", "KeyName");

                    b.HasIndex("DeviceId", "KeyName", "DateTime");

                    b.ToTable("TelemetryData");
                });

            modelBuilder.Entity("IoTSharp.Data.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
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

            modelBuilder.Entity("IoTSharp.Data.AttributeLatest", b =>
                {
                    b.HasBaseType("IoTSharp.Data.DataStorage");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("IoTSharp.Data.TelemetryLatest", b =>
                {
                    b.HasBaseType("IoTSharp.Data.DataStorage");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("IoTSharp.Data.Gateway", b =>
                {
                    b.HasBaseType("IoTSharp.Data.Device");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("IoTSharp.Data.AuditLog", b =>
                {
                    b.HasOne("IoTSharp.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("IoTSharp.Data.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Customer");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("IoTSharp.Data.AuthorizedKey", b =>
                {
                    b.HasOne("IoTSharp.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("IoTSharp.Data.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Customer");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("IoTSharp.Data.Customer", b =>
                {
                    b.HasOne("IoTSharp.Data.Tenant", "Tenant")
                        .WithMany("Customers")
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("IoTSharp.Data.Device", b =>
                {
                    b.HasOne("IoTSharp.Data.AuthorizedKey", null)
                        .WithMany("Devices")
                        .HasForeignKey("AuthorizedKeyId");

                    b.HasOne("IoTSharp.Data.Customer", "Customer")
                        .WithMany("Devices")
                        .HasForeignKey("CustomerId");

                    b.HasOne("IoTSharp.Data.Gateway", "Owner")
                        .WithMany("Children")
                        .HasForeignKey("OwnerId");

                    b.HasOne("IoTSharp.Data.Tenant", "Tenant")
                        .WithMany("Devices")
                        .HasForeignKey("TenantId");

                    b.Navigation("Customer");

                    b.Navigation("Owner");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("IoTSharp.Data.DeviceIdentity", b =>
                {
                    b.HasOne("IoTSharp.Data.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("IoTSharp.Data.Relationship", b =>
                {
                    b.HasOne("IoTSharp.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.HasOne("IoTSharp.Data.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Customer");

                    b.Navigation("IdentityUser");

                    b.Navigation("Tenant");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IoTSharp.Data.AuthorizedKey", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("IoTSharp.Data.Customer", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("IoTSharp.Data.Tenant", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Devices");
                });

            modelBuilder.Entity("IoTSharp.Data.Gateway", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
