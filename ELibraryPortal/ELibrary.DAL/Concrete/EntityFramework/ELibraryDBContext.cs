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
        public virtual DbSet<Entities.Concrete.Type> Types { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<CategoryTagAssignment> CategoryTagAssignments { get; set; }

        public ELibraryDBContext(DbContextOptions<ELibraryDBContext> options) : base(options)
        {

        }
        public ELibraryDBContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

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
