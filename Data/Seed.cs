using IdentityPractice.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityPractice.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.ToDo.Any())
                {
                    context.ToDo.AddRange(new List<ToDo>()
                    {
                        new ToDo()
                        {
                            Title = "List 1",
                            ImageUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            Deadline = new DateTime(2023, 12, 31, 23, 59, 59)
                },
                        new ToDo()
                        {
                            Title = "List 2",
                            ImageUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the second cinema",
                            Deadline = new DateTime(2023, 12, 31, 23, 59, 59)
                        },
                        new ToDo()
                        {
                            Title = "List 3",
                            ImageUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the third cinema",
                            Deadline = new DateTime(2023, 12, 31, 23, 59, 59)
                        },
                        new ToDo()
                        {
                            Title = "List 4",
                            ImageUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the fourth cinema",
                            Deadline = new DateTime(2023, 12, 31, 23, 59, 59)
                        }
                    });
                    context.SaveChanges();
                }
                ////Races
                //if (!context.Races.Any())
                //{
                //    context.Races.AddRange(new List<Race>()
                //    {
                //        new Race()
                //        {
                //            Title = "Running Race 1",
                //            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                //            Description = "This is the description of the first race",
                //            RaceCategory = RaceCategory.Marathon,
                //            Address = new Address()
                //            {
                //                Street = "123 Main St",
                //                City = "Charlotte",
                //                State = "NC"
                //            }
                //        },
                //        new Race()
                //        {
                //            Title = "Running Race 2",
                //            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                //            Description = "This is the description of the first race",
                //            RaceCategory = RaceCategory.Ultra,
                //            AddressId = 5,
                //            Address = new Address()
                //            {
                //                Street = "123 Main St",
                //                City = "Charlotte",
                //                State = "NC"
                //            }
                //        }
                //    });
                //    context.SaveChanges();
                //}
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
        //        string adminUserEmail = "sameergiri@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new User()
        //            {
        //                UserName = "sameergiri",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                ProfileImageUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"

        //            };
        //            await userManager.CreateAsync(newAdminUser, "Sameer@123");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);

        //        }

        //        string appUserEmail = "user@gmail.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new User()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                ProfileImageUrl = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"

        //            };
        //            await userManager.CreateAsync(newAppUser, "Sameer@123");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
