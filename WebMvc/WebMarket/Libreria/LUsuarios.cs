using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMarket.Areas.Usuarios.Models;
using WebMarket.Data;

namespace WebMarket.Libreria
{
    public class LUsuarios : ListObject
    {
        public LUsuarios(
             UserManager<IdentityUser> userManager,
             SignInManager<IdentityUser> signInManager,
             RoleManager<IdentityRole> roleManager,
             ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _usersRole = new LUsuariosRoles();
        }
        public async Task<List<ImputModelRegistrar>> getTUsuariosAsync(string valor, int id)
        {
            List<TUsuario> listUser;
            List<SelectListItem> _listRoles;
            List<ImputModelRegistrar> userList = new List<ImputModelRegistrar>();
            if (valor == null && id.Equals(0))
            {
                listUser = _context.TUsuarios.ToList();
            }
            else
            {
                if (id.Equals(0))
                {
                    listUser = _context.TUsuarios.Where(u => u.Rut.StartsWith(valor) || u.Nombre.StartsWith(valor) ||
              u.Apellido.StartsWith(valor) || u.Email.StartsWith(valor)).ToList();
                }
                else
                {
                    listUser = _context.TUsuarios.Where(u => u.ID.Equals(id)).ToList();
                }
            }
            if (!listUser.Count.Equals(0))
            {
                foreach (var item in listUser)
                {
                    _listRoles = await _usersRole.getRole(_userManager, _roleManager, item.IdUser);
                    var user = _context.Users.Where(u => u.Id.Equals(item.IdUser)).ToList().Last();
                    userList.Add(new ImputModelRegistrar
                    {
                        Id = item.ID,
                        ID = item.IdUser,
                        Rut = item.Rut,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Email = item.Email,
                        Roles = _listRoles[0].Text,
                        Image = item.Image,
                        IdentityUser = user
                    });
                    _listRoles.Clear();
                }
            }
            return userList;
        }
    }
}
