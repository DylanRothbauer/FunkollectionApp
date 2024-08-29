using FunkollectionApp.Models;
using FunkollectionApp.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace FunkollectionApp.Data
{
    public class DataSeeder
    {
        public DataSeeder() { }

        public static void SeedDevelopment(ApplicationDbContext dbContext)
        {
            // Seed data for Users
            //if (!dbContext.Users.Any())
            //{
            //    dbContext.Users.AddRange(
            //        new User {Username = "drothbauer", Password = "admin" }
            //        );
            //    dbContext.SaveChanges();

            //}

            // Seed data for Pops
            if (!dbContext.Pops.Any())
            {
                dbContext.Pops.AddRange(
                    //new Pop {Number = 100, Title = "Wonka", Name = "Willy Wonka", Category = "Movies" },
                    //new Pop {Number = 101, Title = "South Park", Name = "Steven McTowelie"},
                    //new Pop {Number = 102, Title = "Overwatch 2", Name = "Reaper", Category = "Games" },
                    //new Pop {Number = 103, Title = "Stranger Things", Name = "Eleven", Category = "Television" },
                    //new Pop {Number = 104, Title = "Deadpool", Name = "Deadpool"}
                    );
                dbContext.SaveChanges();
            }


                var user = new ApplicationUser
                {
                    UserName = "Email@email.com",
                    NormalizedUserName = "email@email.com",
                    Email = "Email@email.com",
                    NormalizedEmail = "email@email.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };


                if (!dbContext.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(user, "password");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<ApplicationUser>(dbContext);
                    userStore.CreateAsync(user).Wait();
                }

                dbContext.SaveChangesAsync().Wait();

        }
    }
}
