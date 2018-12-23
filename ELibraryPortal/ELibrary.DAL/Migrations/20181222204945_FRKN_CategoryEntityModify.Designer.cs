﻿// <auto-generated />
using System;
using ELibrary.DAL.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ELibrary.DAL.Migrations
{
    [DbContext(typeof(ELibraryDBContext))]
    [Migration("20181222204945_FRKN_CategoryEntityModify")]
    partial class FRKN_CategoryEntityModify
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ELibrary.Entities.Concrete.AppFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlobPath");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Extension");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<Guid>("ModuleId");

                    b.Property<int>("ModuleType");

                    b.Property<string>("Name");

                    b.Property<string>("UniqueName");

                    b.HasKey("Id");

                    b.HasIndex("UniqueName")
                        .IsUnique()
                        .HasFilter("[UniqueName] IS NOT NULL");

                    b.ToTable("AppFiles");
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("Gender");

                    b.Property<string>("IdentityNumber");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
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

            modelBuilder.Entity("ELibrary.Entities.Concrete.AppType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorPhoto");

                    b.Property<string>("Biography")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("Birthdate");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Surname")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("BookSummary")
                        .HasMaxLength(4000);

                    b.Property<int>("BooksPhoto");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("EditionDate");

                    b.Property<string>("ISBN");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("NumberPages");

                    b.Property<Guid>("PublisherId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AppTypeId");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AppTypeId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.CategoryTagAssignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<Guid>("CategoryId");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<Guid>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TagId");

                    b.ToTable("CategoryTagAssignments");
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.AppIdentityRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");


                    b.ToTable("AppIdentityRole");

                    b.HasDiscriminator().HasValue("AppIdentityRole");
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.Book", b =>
                {
                    b.HasOne("ELibrary.Entities.Concrete.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ELibrary.Entities.Concrete.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.Category", b =>
                {
                    b.HasOne("ELibrary.Entities.Concrete.AppType", "AppType")
                        .WithMany()
                        .HasForeignKey("AppTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ELibrary.Entities.Concrete.CategoryTagAssignment", b =>
                {
                    b.HasOne("ELibrary.Entities.Concrete.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ELibrary.Entities.Concrete.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ELibrary.Entities.Concrete.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ELibrary.Entities.Concrete.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ELibrary.Entities.Concrete.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ELibrary.Entities.Concrete.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ELibrary.Entities.Concrete.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
