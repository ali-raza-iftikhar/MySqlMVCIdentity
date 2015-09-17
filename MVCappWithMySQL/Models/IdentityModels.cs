﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
//using MySql.AspNet.Identity;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;


namespace MVCappWithMySQL.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /*public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

      
    }*/

    public class ApplicationDbContext : MySQLDatabase
    {
        public ApplicationDbContext(string connectionName)
            : base(connectionName)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext("DefaultConnection");
        }

        public ApplicationDbContext()
        {
        }
    }
}