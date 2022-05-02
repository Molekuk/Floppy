using Floppy.Managers.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Floppy.Pages.Lesson
{
    public class LessonsModel : PageModel
    {
        public LessonsModel()
        {

        }
        public async Task<IActionResult> OnGetExitAsync([FromServices] IUserManager userManager)
        {
           await userManager.SignOutAsync();
           return RedirectToPage("Index");
        }
    }
}
