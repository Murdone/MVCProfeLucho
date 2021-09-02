using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMarket.Libreria
{
    public class LUsuariosRoles
    {
        public List<SelectListItem> getRoles(RoleManager<IdentityRole> roleManager)
        {
            List<SelectListItem> _selectLists = new List<SelectListItem>();
            var role = roleManager.Roles.ToList();
            role.ForEach(item => {
                _selectLists.Add(new SelectListItem
                {
                Value =item.Id,
                Text = item.Name
                }); 
            });
            return _selectLists;
        }
    }
}
