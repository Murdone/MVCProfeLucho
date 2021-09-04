using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using WebMarket.Data;

namespace WebMarket.Libreria
{
    public class ListObject
    {
        public LUsuariosRoles _usersRole;

        public IdentityError _identityError;
        public ApplicationDbContext _context;
        public IWebHostEnvironment _environment;

        public RoleManager<IdentityRole> _roleManager;
        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager;
    }
}
