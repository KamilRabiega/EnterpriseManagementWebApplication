using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseManagementApp.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var productionRoleId = "ab2aed5b-2505-4011-b6e3-d7aea499fbb0";
            var magazineRoleId = "931f8a9e-0b6e-47e3-a77c-9bc734d99a1e";
            var financeRoleId = "25130d10-ec6c-4023-bda9-e4684f35a55b";
            var boardRoleId = "2725d629-db33-4423-adca-27a89f547db4";
            var userRoleId = "7c19e5f1-e8ed-49e0-bd6a-0b6aaf411cc9";
            var adminRoleId = "f7ab4958-b811-471a-ade0-6b4d59fb356d";


            //Here we will seed Roles (Production, Magazine, Finance, Board, User, Admin)
            var roles = new List<IdentityRole>
            {
                //Production Role
                new IdentityRole()
                {
                    Name= "Production",
                    NormalizedName = "Production",
                    Id = productionRoleId,
                    ConcurrencyStamp = productionRoleId
                },

                //Magazine Role
                new IdentityRole()
                {
                    Name= "Magazine",
                    NormalizedName = "Magazine",
                    Id = magazineRoleId,
                    ConcurrencyStamp = magazineRoleId
                },

                //Finance Role
                new IdentityRole()
                {
                    Name= "Finance",
                    NormalizedName = "Finance",
                    Id = financeRoleId,
                    ConcurrencyStamp = financeRoleId
                },

                //Board Role
                new IdentityRole()
                {
                    Name= "Board",
                    NormalizedName = "Board",
                    Id = boardRoleId,
                    ConcurrencyStamp = boardRoleId
                },

                //User Role
                new IdentityRole()
                {
                    Name= "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                },

                //Admin Role
                new IdentityRole()
                {
                    Name= "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
            };
            builder.Entity<IdentityRole>().HasData(roles); //Whenever EFCore Migrations will be running, it will always insert these roles to DB


            //Here we will seed an Admin (cause there will be only one admin account)
            var adminId = "a2918c9e-cc63-4d1e-8d90-647b4ba66561";
            var adminUser = new IdentityUser()
            {
                Id = adminId,
                UserName = "admin@emapp.com",
                Email = "admin@emapp.com",
                NormalizedEmail = "admin@emapp.com".ToUpper(),
                NormalizedUserName = "admin@emapp.com".ToUpper()
            };

            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "Admin#321#");

            builder.Entity<IdentityUser>().HasData(adminUser);

            //Add all roles for admin 

            var identityAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId= adminRoleId,
                    UserId= adminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId= userRoleId,
                    UserId= adminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId= boardRoleId,
                    UserId= adminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId= financeRoleId,
                    UserId= adminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId= magazineRoleId,
                    UserId= adminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId= productionRoleId,
                    UserId= adminId,
                },
            };
            builder.Entity<IdentityUserRole<string>>().HasData(identityAdminRoles);
        }

        
    }
}
