﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UsuariosAPI.Models;

namespace UsuariosAPI.Data
{
    public class UsuarioContext : IdentityDbContext<IdentityUserCustomizado, IdentityRole<int>, int>
    {
        private readonly IConfiguration _configuration;

        public UsuarioContext(DbContextOptions<UsuarioContext> options, IConfiguration configuration) :base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityUserCustomizado admin = new IdentityUserCustomizado
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.com",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            PasswordHasher<IdentityUserCustomizado> hasher = new PasswordHasher<IdentityUserCustomizado>();
            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("AdminInfo:Senha"));

            builder.Entity<IdentityUserCustomizado>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 99999, Name = "admin", NormalizedName = "ADMIN" }
            );

            builder.Entity<IdentityRole<int>>().HasData(
               new IdentityRole<int> { Id = 99997, Name = "regular", NormalizedName = "REGULAR" }
           );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 }
            );
        }
    }
}