using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenBasedAuthentication_PoC
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext()
            : base("AuthContext")
        {
        }
    }
}