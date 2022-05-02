using Floppy.Managers.Users;
using Floppy.Models;
using Floppy.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floppy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserManager _userManager;
        public IndexModel(IUserManager userManager)
        {
           _userManager = userManager;
        }


        public async Task<IActionResult> OnPostRegisterAsync(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userManager.RegisterAsync(model);
                if (!result.Succeeded)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToPage("Main");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostLoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.SignInAsync(model);
                if (!result.Succeeded)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToPage("Main");
            }
            return Page();
        }
    }
}
