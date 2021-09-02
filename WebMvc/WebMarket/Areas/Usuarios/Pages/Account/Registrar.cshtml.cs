using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMarket.Areas.Usuarios.Models;
using WebMarket.Data;
using WebMarket.Libreria;

namespace WebMarket.Areas.Usuarios.Pages.Account
{
    public class RegistrarModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _RoleManager;
        private LUsuariosRoles _UsuariosRole;
        private static ImputModel _DataInput;
        private ApplicationDbContext _context;

        public RegistrarModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> RoleManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _RoleManager = RoleManager;
            _context = context;
            _UsuariosRole = new LUsuariosRoles();
        }

        public void OnGet() //peticiones get
        {
            if (_DataInput != null)
            {
                Input = _DataInput;
                Input.rolesLitas = _UsuariosRole.getRoles(_RoleManager);
                Input.AvatarImage = null;
            }
            else
            {
                Input = new ImputModel
                {
                    rolesLitas = _UsuariosRole.getRoles(_RoleManager)
                };
            }
        }
        [BindProperty] // propiedad para ingresar a imput model
        public ImputModel Input { get; set; }
        public class ImputModel : ImputModelRegistrar
        {
            public IFormFile AvatarImage { get; set; }
            public string ErrorMessage { get; set; }
            public List<SelectListItem> rolesLitas { get; set; }
        }
        public async Task<IActionResult> OnPost()  //peticion por post 
        {
            if (await SaveAsync())
            {
                return Redirect("/Usuarios/Usuarios?area=Usuarios");
            }
            else
            {
                return Redirect("/Registro/");
            }
        }
        private async Task<bool> SaveAsync()
        {
            _DataInput = Input;
            var valor = false;
            if (ModelState.IsValid)
            {
                var userList = _userManager.Users.Where(u=> u.Email.Equals(Input.Email)).ToList(); //referencia a la clase identity que maneja y adimistra los usuarios si hay email revisa si el correo esta registrado
                if (userList.Count.Equals(0))
                {
                    var strategy = _context.Database.CreateExecutionStrategy(); //aca indicamos a la base de datos que aremos una estrategia para insertar datos simultaneamente
                    await strategy.ExecuteAsync(async () => 
                    {
                        using (var transaction = _context.Database.BeginTransaction()) 
                        {
                            try 
                            {
                                var user = new IdentityUser
                                {
                                    UserName = Input.Email,
                                    Email = Input.Email,
                                    PhoneNumber = Input.NumeroTelefono
                                };
                                var resultado = await _userManager.CreateAsync(user, Input.Password);
                                if (resultado.Succeeded)
                                {
                                    await _userManager.AddToRoleAsync(user, Input.Roles);
                                    var dataUser = _userManager.Users.Where(u => u.Email.Equals(Input.Email)).ToList().Last(); //aca buscamos la informacion del ultimo usuario que acabamos de registrar
                                    var imageByte = await _uploadimage.ByteAvatarImageAsync(Input.AvatarImage, _environmet, "Imagenes/Imagenes");
                                }
                                else 
                                {
                                   foreach (var item in resultado.Errors)
                                    {
                                        _DataInput.ErrorMessage = item.Description;
                                    }
                                    valor = false;
                                }
                            }
                            catch(Exception ex)
                            {
                                _DataInput.ErrorMessage = ex.Message;
                                transaction.Rollback(); // desacer los cambios si hay algun error 
                                valor = false;
                            }
                        }
                    });
                }
                else 
                {
                    _DataInput.ErrorMessage = $"El {Input.Email} ya esta registrado";
                    valor = false;
                }
                
            }
            else 
            {
                _DataInput.ErrorMessage = "No Deje Campos Vacion selecione el rol";
                 valor = false;
            }

            return valor;
        }
    }
}
