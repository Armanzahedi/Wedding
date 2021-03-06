using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wedding.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using Wedding.Core.Utility;

namespace Wedding.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetDefaultQuery();
        Task<User> GetById(string id);
        Task<User> CreateUser(User model, string Password);
        Task<User> UpdateUser(User model);
        Task<IdentityResult> Remove(string id);
        Task<bool> UserNameExists(string username, string id = null);
        Task<bool> phoneNumberExists(string phone, string id = null);
        Task<bool> EmailExists(string email, string id = null);
        Task<User> UploadUserImage(string id, IFormFile file);
        Task<User> GetUserByUserName(string userName);
        IQueryable<User> FilterUsers(string searchString = null);
        Task<IdentityResult> ResetPasswordToDefault(string userId);
        Task<User> DeleteUser(string userId);
    }
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ISystemParameterRepository _systemParameterRepo;
        public UserRepository( MyDbContext context,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ISystemParameterRepository systemParameterRepo)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _systemParameterRepo = systemParameterRepo;
        }

        public IQueryable<User> GetDefaultQuery()
        {
            return _context.Users.Where(u=>u.IsDeleted == false);
        }


        public async Task<User> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> Remove(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;

            var userRoles = await _context.UserRoles.Where(r => r.UserId == user.Id).ToListAsync();
            foreach (var role in userRoles)
                _context.UserRoles.Remove(role);
            _context.SaveChanges();

            if (user.Avatar != null)
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", user.Avatar)))
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", user.Avatar));

            var result = await _userManager.DeleteAsync(user);
            return result;
        }

        public async Task<bool> UserNameExists(string username, string id = null)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && user.IsDeleted == false)
            {
                if (string.IsNullOrEmpty(id))
                {
                    return true;
                }
                else
                {
                    if (user.Id != id)
                        return true;
                }
            }

            return false;
        }

        public async Task<bool> phoneNumberExists(string phone, string id = null)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u=>u.IsDeleted == false && u.PhoneNumber == phone);
            if (user != null && user.IsDeleted == false)
            {
                if (string.IsNullOrEmpty(id))
                    return true;

                if (user.Id != id)
                    return true;
            }

            return false;
        }

        public async Task<bool> EmailExists(string email, string id = null)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && user.IsDeleted == false)
            {
                if (string.IsNullOrEmpty(id))
                {
                    return true;
                }
                else
                {
                    if (user.Id != id)
                        return true;
                }
            }

            return false;
        }

        public async Task<User> UploadUserImage(string id, IFormFile file)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user.Avatar != null)
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", user.Avatar)))
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", user.Avatar));

            var imageName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", imageName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            user.Avatar = imageName;
            return user;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName.ToLower());
            return user;
        }
        public IQueryable<User> FilterUsers(string searchString = null)
        {
            IQueryable<User> users = null;

            users = this.GetDefaultQuery();

            if (searchString != null)
                users = users
                    .Where(u => u.UserName.ToLower().Contains(searchString.ToLower()) || u.Email.ToLower().Contains(searchString.ToLower()));
            return users;
        }

        private static List<string> GetRoles(MyDbContext _context, string userId)
        {
            var roleIds = _context.UserRoles
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId)
                .ToList();

            var roles = _context.Roles
                .Where(x => roleIds.Contains(x.Id))
                .Select(r => r.Name).ToList();


            return roles;
        }
        public async Task<User> CreateUser(User model, string Password)
        {
            model.SecurityStamp = Guid.NewGuid().ToString();
            await _userManager.CreateAsync(model, Password);

            return model;
        }
        public async Task<User> UpdateUser(User model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<IdentityResult> ResetPasswordToDefault(string userId)
        {
            var sys = await _systemParameterRepo.GetById(DefaultValues.UserDefaultPassword_sys_id);
            var defaultPassword = sys?.Value ?? "User@123456";
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemovePasswordAsync(user);
            var result = await _userManager.AddPasswordAsync(user, defaultPassword);
            return result;
        }

        public async Task<User> DeleteUser(string userId)
        {
            var user = await this.GetById(userId);
            user.IsDeleted = true;
            user.UserName = null;
            user.NormalizedUserName = null;
            await this.UpdateUser(user);

            return user;
        }
    }

}
