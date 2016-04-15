using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TokenBasedAuthentication_PoC.Models;

namespace TokenBasedAuthentication_PoC
{
    public class AuthRepository :IDisposable
    {
        private AuthContext _context;
        private UserManager<IdentityUser> _userManager;

        private List<UserModel> _users = null;

        public AuthRepository()
        {
            // ToDo: Here try to change with our own DB
            _context = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
            _users = GetUsers();
        }

        public async Task<UserModel> FindUser(string email, string password)
        {
            UserModel user = _users.Find(u => u.Email == email && u.Password == password);

            return user;
        }

        public async Task<IdentityResult> RegisterAspUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindAspUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();
        }

        private List<UserModel> GetUsers()
        {
            List<UserModel> usersList = new List<UserModel>
            {
                new UserModel { Email = "user@maestrohealth.com", Password = "password"},
                new UserModel { Email = "user@maestrohealth.com", Password = "password"}
            };

            return usersList;
        }
    }
}