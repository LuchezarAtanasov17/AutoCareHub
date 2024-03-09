﻿using AutoCareHub.Data.Configuration;
using AutoCareHub.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Data
{
    public class AutoCareHubDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AutoCareHubDbContext(DbContextOptions<AutoCareHubDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var timeOnlyToTimeSpanConverter = new TimeOnlyToTimeSpanConverter();

            modelBuilder.Entity<Appointment>(builder =>
            {
                builder.HasOne(x => x.Service)
                    .WithMany(x => x.Appointments)
                    .HasForeignKey(x => x.ServiceId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(x => x.User)
                    .WithMany(x => x.Appointments)
                    .HasForeignKey(x => x.UserId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder.HasOne(x => x.MainCategory)
                    .WithMany(x => x.Appointments)
                    .HasForeignKey(x => x.MainCategoryId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Rating>(builder =>
            {
                builder.HasOne(x => x.Service)
                    .WithMany(x => x.Ratings)
                    .HasForeignKey(x => x.ServiceId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(x => x.User)
                    .WithMany(x => x.Ratings)
                    .HasForeignKey(x => x.UserId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Service>(builder =>
            {
                builder.Property(x => x.OpenTime)
                    .HasConversion(timeOnlyToTimeSpanConverter);

                builder.Property(x => x.CloseTime)
                    .HasConversion(timeOnlyToTimeSpanConverter);

                builder.HasOne(x => x.User)
                    .WithMany(x => x.Services)
                    .HasForeignKey(x => x.UserId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Comment>(builder =>
            {
                builder.HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(x=>x.Service)
                .WithMany(x=> x.Comments)
                .HasForeignKey(x=>x.ServiceId)
                .HasPrincipalKey(x=>x.Id) 
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<MainCategoryService>(builder =>
            {
                builder.HasKey(cs => new { cs.MainCategoryId, cs.ServiceId });

                builder.HasOne(x => x.MainCategory)
                    .WithMany(x => x.MainCategoryServices)
                    .HasForeignKey(x => x.MainCategoryId)
                    .HasPrincipalKey(x => x.Id);

                builder.HasOne(x => x.Service)
                    .WithMany(x => x.MainCategoryServices)
                    .HasForeignKey(x => x.ServiceId)
                    .HasPrincipalKey(x => x.Id);
            });

            modelBuilder.Entity<SubCategory>(builder =>
            {
                builder.HasOne(x => x.MainCategory)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.MainCategoryId)
                .HasPrincipalKey(x => x.Id);
            });

            modelBuilder.ApplyConfiguration(new MainCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MainCategoryServiceConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<MainCategory> MainCategories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<MainCategoryService> MainCategoryServices { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
