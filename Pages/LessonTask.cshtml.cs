using Floppy.Managers.Users;
using Floppy.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Floppy.Pages
{
    public class LessonTaskModel : PageModel
    {
        public Progress Progress { get; set; }
        private readonly IUserManager _userManager;
        public LessonTaskModel(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult OnGet()
        {
           return RedirectToPage("Lessons");
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id > await _userManager.GetCurrentLessonAsync(User.Identity.Name))
                return RedirectToPage("Lessons");
            Progress = await _userManager.GetProgressAsync(User.Identity.Name);
            return Page();
        }
    }
}
