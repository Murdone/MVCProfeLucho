using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMarket.Areas.Usuarios.Models;
using WebMarket.Data;
using WebMarket.Libreria;

namespace WebMarket.Areas.Usuarios.Pages.Account
{
    [Authorize]
    [Area("Usuarios")]
    public class RegistrarModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;
        private LUsuariosRoles _usersRole;
        private static InputModel _dataInput;
        private Uploadimage _uploadimage;
        private static ImputModelRegistrar _dataUser1, _dataUser2;
        private IWebHostEnvironment _environment;
        public RegistrarModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _environment = environment;
            _usersRole = new LUsuariosRoles();
            _uploadimage = new Uploadimage();
        }

        public void OnGet(int id)
        {
            if (id.Equals(0))
            {
                _dataUser2 = null;
            }
            if (_dataInput != null || _dataUser1 != null || _dataUser2 != null)
            {
                if (_dataInput != null)
                {
                    Input = _dataInput;
                    Input.rolesLista = _usersRole.getRoles(_roleManager);
                    Input.AvatarImage = null;
                }
                else
                {
                    if (_dataUser1 != null || _dataUser2 != null)
                    {
                        if (_dataUser2 != null)
                            _dataUser1 = _dataUser2;
                        Input = new InputModel
                        {
                            Id = _dataUser1.Id,
                            Nombre = _dataUser1.Nombre,
                            Apellido = _dataUser1.Apellido,
                            Rut = _dataUser1.Rut,
                            Email = _dataUser1.Email,
                            Image = _dataUser1.Image,
                            NumeroTelefono = _dataUser1.IdentityUser.PhoneNumber,
                            rolesLista = getRoles(_dataUser1.Roles),
                        };
                        if (_dataInput != null)
                        {
                            Input.ErrorMessage = _dataInput.ErrorMessage;
                        }
                    }
                }
            }
            else
            {
                Input = new InputModel
                {
                    rolesLista = _usersRole.getRoles(_roleManager)
                };
            }

            _dataUser2 = _dataUser1;
            _dataUser1 = null;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel : ImputModelRegistrar
        {
            public IFormFile AvatarImage { get; set; }
            // [TempData]
            //public string ErrorMessage { get; set; }
            public List<SelectListItem> rolesLista { get; set; }
        }
        public async Task<IActionResult> OnPost(String dataUser)
        {
            if (dataUser == null)
            {
                if (_dataUser2 == null)
                {
                    if (User.IsInRole("Admin"))
                    {
                        if (await SaveAsync())
                        {
                            return Redirect("/Usuarios/Usuarios?area=Usuarios");
                        }
                        else
                        {
                            return Redirect("/Registro");
                        }
                }
                else
                {
                    return Redirect("/Usuarios/Usuarios?area=Usuarios");
                }

            }
                else
                {
                    if (User.IsInRole("Admin"))
                    {
                        if (await UpdateAsync())
                        {
                            var url = $"/Usuarios/Account/Detallles?id={_dataUser2.Id}";
                            _dataUser2 = null;
                            return Redirect(url);
                        }
                        else
                        {
                            return Redirect("/Registro");
                        }
                }
                    else
                {
                    return Redirect("/Usuarios/Usuarios?area=Usuarios");
                }

            }

            }
            else
            {
                _dataUser1 = JsonConvert.DeserializeObject<ImputModelRegistrar>(dataUser);
                return Redirect("/Registro?id=1");
            }

        }

        private async Task<bool> SaveAsync()
        {
            _dataInput = Input;
            var valor = false;
            if (ModelState.IsValid)
            {
                var userList = _userManager.Users.Where(u => u.Email.Equals(Input.Email)).ToList();
                if (userList.Count.Equals(0))
                {
                    var strategy = _context.Database.CreateExecutionStrategy();
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
                                var result = await _userManager.CreateAsync(user, Input.Password);
                                if (result.Succeeded)
                                {
                                    await _userManager.AddToRoleAsync(user, Input.Roles);
                                    var dataUser = _userManager.Users.Where(u => u.Email.Equals(Input.Email)).ToList().Last();
                                    var imageByte = await _uploadimage.ByteAvatarImageAsync(
                                        Input.AvatarImage, _environment, "Imagenes/Imagenes/Usuario.png");
                                    var t_user = new TUsuario
                                    {
                                        Nombre = Input.Nombre,
                                        Apellido = Input.Apellido,
                                        Rut = Input.Rut,
                                        Email = Input.Email,
                                        IdUser = dataUser.Id,
                                        Image = imageByte,
                                    };
                                    await _context.AddAsync(t_user);
                                    _context.SaveChanges();

                                    transaction.Commit();
                                    _dataInput = null;
                                    valor = true;
                                }
                                else
                                {
                                    foreach (var item in result.Errors)
                                    {
                                        _dataInput.ErrorMessage = item.Description;
                                    }
                                    valor = false;
                                    transaction.Rollback();
                                }
                            }
                            catch (Exception ex)
                            {
                                _dataInput.ErrorMessage = ex.Message;
                                transaction.Rollback();
                                valor = false;
                            }
                        }
                    });
                }
                else
                {
                    _dataInput.ErrorMessage = $"El {Input.Email} ya esta registrado";
                    valor = false;
                }
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _dataInput.ErrorMessage += error.ErrorMessage;
                    }
                }
                valor = false;
            }

            return valor;
        }
        private List<SelectListItem> getRoles(String role)
        {
            List<SelectListItem> rolesLista = new List<SelectListItem>();
            rolesLista.Add(new SelectListItem
            {
                Text = role
            });
            var roles = _usersRole.getRoles(_roleManager);
            roles.ForEach(item =>
            {
                if (item.Text != role)
                {
                    rolesLista.Add(new SelectListItem
                    {
                        Text = item.Text
                    });
                }
            });
            return rolesLista;
        }

        private async Task<bool> UpdateAsync()
        {
            var valor = false;
            byte[] imageByte = null;
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var identityUser = _userManager.Users.Where(u => u.Id.Equals(_dataUser2.ID)).ToList().Last();
                        identityUser.UserName = Input.Email;
                        identityUser.Email = Input.Email;
                        identityUser.PhoneNumber = Input.NumeroTelefono;
                        _context.Update(identityUser);
                        await _context.SaveChangesAsync();

                        if (Input.AvatarImage == null)
                        {
                            imageByte = _dataUser2.Image;
                        }
                        else
                        {
                            imageByte = await _uploadimage.ByteAvatarImageAsync(Input.AvatarImage, _environment, "");
                        }
                        var t_user = new TUsuario
                        {
                            ID = _dataUser2.Id,
                            Nombre = Input.Nombre,
                            Apellido = Input.Apellido,
                            Rut = Input.Rut,
                            Email = Input.Email,
                            IdUser = _dataUser2.ID,
                            Image = imageByte,
                        };
                        _context.Update(t_user);
                        _context.SaveChanges();
                        if (_dataUser2.Roles != Input.Roles)
                        {
                            await _userManager.RemoveFromRoleAsync(identityUser, _dataUser2.Roles);
                            await _userManager.AddToRoleAsync(identityUser, Input.Roles);
                        }
                        transaction.Commit();

                        valor = true;
                    }
                    catch (Exception ex)
                    {
                        _dataInput.ErrorMessage = ex.Message;
                        transaction.Rollback();
                        valor = false;
                    }
                }
            });
            return valor;
        }
    }
}
