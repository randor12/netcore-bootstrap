using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreBootstrap.Models.Database;

namespace NetCoreBootstrap.Repositories
{
    public class UserRepository
    {
        private readonly DbContextOptions<DataBaseContext> _options;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(DbContextOptions<DataBaseContext> options, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._options = options;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            using(var context = Context)
            {
                context.Entry(user).Collection(u => u.Roles).Load();
                return user;
            }
        }

        public List<User> GetAllUsers()
        {
            using(var context = Context)
            {
                return context.Users.OrderBy(u => u.Email).Include(u => u.Roles).ToList();
            }
        }

        public List<IdentityRole> GetAllRoles()
        {
            using(var context = Context)
            {
                return context.Roles.OrderBy(r => r.Name).Include(r => r.Users).ToList();
            }
        }

        public List<SelectListItem> GetRoles()
        {
            var roles = new List<SelectListItem>();
            foreach(var role in RoleManager.Roles.OrderBy(r => r.Name).ToList())
            {
                roles.Add(new SelectListItem { Text = role.Name, Value = role.Name });
            }
            return roles;
        }

        public async Task<IdentityResult> AddRoleToUser(User user, string role)
        {
            return await UserManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> CreateRole(string role)
        {
            return await RoleManager.CreateAsync(new IdentityRole(role));
        }
        
        public UserManager<User> UserManager
        {
            get { return _userManager; }
        }

        public RoleManager<IdentityRole> RoleManager
        {
            get { return _roleManager; }
        }

        public DataBaseContext Context
        {
            get { return new DataBaseContext(_options); }
        }
    }
}