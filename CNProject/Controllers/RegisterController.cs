using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNProject.Models;
using CNProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CNProject.Controllers
{
    public class RegisterController : Controller
    {
        public UserManager<AppUser> userManager;
        private SignInManager<AppUser> sgnMgr;

        public RegisterController(UserManager<AppUser> userMgr, SignInManager<AppUser> signInManager)
        {
            userManager = userMgr;
            sgnMgr  = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegisterActionAsync(UserViewModel viewModel)

        {
            AppUser user = new AppUser();
            user.Email = viewModel.Email;
            user.UserName = viewModel.Name;
            await userManager.CreateAsync(user, viewModel.password);
            return Redirect("/Home/Index");
        }

        public IActionResult Login() => View();

        public IActionResult LoginActionAsync()
        {

        }
    }
}