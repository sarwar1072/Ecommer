using Autofac;
using Autofac.Core.Lifetime;
using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        public AccountController(ILifetimeScope scope,IUserAccessor userAccessor):base(scope,userAccessor) 
        {
                
        }
        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl = null!)
        {
            var model = _scope.Resolve<RegisterModel>();
            model.ReturnUrl = returnUrl;
            await model.GetExternalAuthenticationSchemesAsync();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            model.Resolve(_scope);
            model.ReturnUrl ??= Url.Content("~/");
            await model.GetExternalAuthenticationSchemesAsync();
            if (ModelState.IsValid)
            {              
                    var result = await model.CreateAsync();
                    if (result.Succeeded)
                    {
                        if (model.RequireConfirmedAccount())
                        {
                            return RedirectToAction("RegisterConfirmation", new { email = model.Email, returnUrl = model.ReturnUrl });
                        }
                        //else
                        //{
                        //    return RedirectToAction("Index", "Question", new { area = "ForPost" });
                        //}
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }                            
            }
            return View(model);
        }

        public async Task<IActionResult> RegisterConfirmation(string email, string returnUrl = null)
        {
            var model = _scope.Resolve<RegistrationConfirmationModel>();
            var registerModel = _scope.Resolve<RegisterModel>();

            if (email == null)
            {
                return RedirectToAction("Register");
            }
          
                //var user = await registerModel.FindByEmailAsync(email);
                //if (user == null)
                //{
                //    return NotFound($"Unable to load user with email '{email}'.");
                //}

                model.Email = email;
                // await registerModel.EmailConfirmationTokenAsync();
                       
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            var model = _scope.Resolve<LoginModel>();
            var registerModel = _scope.Resolve<RegisterModel>();

            if (!string.IsNullOrEmpty(model.ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, model.ErrorMessage);
            }
            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await model.SignOutAsync();
            await registerModel.GetExternalAuthenticationSchemesAsync();
            model.ReturnUrl = returnUrl;
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            model.Resolve(_scope);
            var registerModel = _scope.Resolve<RegisterModel>();
            model.ReturnUrl ??= Url.Content("~/");

            await registerModel.GetExternalAuthenticationSchemesAsync();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await model.PasswordSignInAsync();
                if (result.Succeeded)
                {                   
                    await model.RedirectByUserRole();
                    return LocalRedirect(model.ReturnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null!)
        {
            var model = _scope.Resolve<LoginModel>();
            await model.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction();
            }
        }
    }
}
