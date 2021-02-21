using Microsoft.AspNetCore.Identity;
using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Services
{
    public interface IIdentityService
    {
        Task CreateRootAccount();

        Task CreateNewRole(string rolename);

        Task<IdentityResult> CreateNewUser(ApplicationUser user, string password);

        Task AddUserToRole(ApplicationUser user, string rolename);

        IEnumerable<ApplicationUser> GetAllUser();

        IEnumerable<IdentityRole> GetAllRoles();
    

    }
}
