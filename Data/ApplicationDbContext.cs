using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TodoItem> Items { get; set; }
        
        //fix for "Specified key was too long" error message in migrations. From https://www.junian.net/aspnet-core-mysql-ubuntu-16-04/
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
        
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.Id)  
                .HasMaxLength(255));  
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedEmail)  
                .HasMaxLength(255));  
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedUserName)  
                .HasMaxLength(255));  
        
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id)  
                .HasMaxLength(255));  
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName)  
                .HasMaxLength(255));  
        
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)  
                .HasMaxLength(255));  
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)  
                .HasMaxLength(255));  
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)  
                .HasMaxLength(255));  

            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)  
                .HasMaxLength(255));  
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)  
                .HasMaxLength(255));  

            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)  
                .HasMaxLength(255));  
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)  
                .HasMaxLength(255));  
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)  
                .HasMaxLength(255));  

            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)  
                .HasMaxLength(255));  
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)  
                .HasMaxLength(255));  
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)  
                .HasMaxLength(255));  
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)  
                .HasMaxLength(255));  
        }

    }
}
