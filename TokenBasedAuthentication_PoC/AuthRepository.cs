using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using TokenBasedAuthentication_PoC.Models;

namespace TokenBasedAuthentication_PoC
{
    public class AuthRepository :IDisposable
    {
        private AuthContext _context;
        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            // ToDo: Here try to change with our own DB
            _context = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();
        }
    }
}