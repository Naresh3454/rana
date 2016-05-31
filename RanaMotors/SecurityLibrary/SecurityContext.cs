using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class SecurityContext : IdentityDbContext<AppUser>
    {
        public SecurityContext() : base("SecurityCon",false )
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

        }

        public static SecurityContext Create()
        {
            return new SecurityContext();
        }
    }
}
