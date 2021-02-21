using Microsoft.AspNetCore.Identity;
using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
    

        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
          
        }

        public async Task AddUserToRole(ApplicationUser user, string rolename)
        {

            await _userManager.AddToRoleAsync(user, rolename);
        }


        public async Task CreateNewRole(string rolename)
        {
            await _roleManager.CreateAsync(new IdentityRole(rolename));
        }



        public async Task<IdentityResult> CreateNewUser(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);

        }


        public async Task CreateRootAccount()
        {
            if (!_userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin@domain",
                    Email = "admin@domain",
                    FirstName = "Admin",
                    LastName = "Account"
                };
                var result = await _userManager.CreateAsync(user, "BytMig123!");

                if (result.Succeeded)
                {
                    if (!_roleManager.Roles.Any())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Admin"));
                        await _roleManager.CreateAsync(new IdentityRole("Student"));
                        await _roleManager.CreateAsync(new IdentityRole("Teacher"));

                    }

                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }

        public IEnumerable<ApplicationUser> GetAllUser()
        {
            return _userManager.Users;
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return _roleManager.Roles;
        }

       
    }
}
