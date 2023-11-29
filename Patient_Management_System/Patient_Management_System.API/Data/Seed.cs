using Microsoft.AspNetCore.Identity;
using Patient_Management_System.API.Data;
using Patient_Management_System.Core.Entities;

namespace Patient_Management_System.API.Data;

public class Seed
{
    public static async Task Initialize(
        ApplicationDbContext context,
        UserManager<ExtendedIdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        context.Database.EnsureCreated();

        string  roleAdmin = "Admin", roleUser = "Manager", roleDEO="Deo";

        string UserName = "AkmRafiq", password = "Rafiq@123";
        string email = "rafiq@gmail.com",name="Project Owner";
        if (await roleManager.FindByNameAsync(roleAdmin) ==null)
            await roleManager.CreateAsync(new IdentityRole(roleAdmin));

        if (await roleManager.FindByNameAsync(roleUser) == null)
            await roleManager.CreateAsync(new IdentityRole(roleUser));

        if (await roleManager.FindByNameAsync(roleDEO) == null)
            await roleManager.CreateAsync(new IdentityRole(roleDEO));

        if (await userManager.FindByNameAsync(UserName) ==null)
        {
            var user = new ExtendedIdentityUser
            {
                Name=name,
                UserName= UserName,
                Email = email,
                PhoneNumber = "01777121212"
            };

            var result = await userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await userManager.AddPasswordAsync(user, password);
                await userManager.AddToRoleAsync(user, roleAdmin);
            }
            _ = user.Id;
        }

    }
}