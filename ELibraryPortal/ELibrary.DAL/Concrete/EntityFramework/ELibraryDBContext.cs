using ELibrary.DAL.Configuration;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.DAL.Concrete.EntityFramework
{
    public class ELibraryDBContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<AppIdentityRole> AppIdentityRoles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Entities.Concrete.AppType> Types { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        //public virtual DbSet<CategoryTagAssignment> CategoryTagAssignments { get; set; }
        public virtual DbSet<AppFile> AppFiles { get; set; }
        public virtual DbSet<UserFavoritAndReadBook> UserFavoritAndReadBook { get; set; }
        public virtual DbSet<UserRates> UserRates { get; set; }
        public virtual DbSet<CategoryTagAssigment> CategoryTagAssigments { get; set; }
        public virtual DbSet<UserReadPage> UserReadPage { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        public ELibraryDBContext(DbContextOptions<ELibraryDBContext> options) : base(options)
        {

        }
        public ELibraryDBContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppFile>()
                .HasIndex(u => u.UniqueName)
                .IsUnique();
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppConfiguration.Instance.SqlDataConnection);
            }
        }
    }
}
