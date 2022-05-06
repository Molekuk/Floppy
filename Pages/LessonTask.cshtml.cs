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
        public int Id { get; set; }
        private readonly IUserManager _userManager;
        public LessonTaskModel(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id > await _userManager.GetCurrentLessonAsync(User.Identity.Name)||id<1)
                return RedirectToPage("Lessons");
            Progress = await _userManager.GetProgressAsync(User.Identity.Name);
            Id = id;
            return Page();
        }

        public async Task<IActionResult> OnPostGrammarAsync(int id)
        {
            if (id > await _userManager.GetCurrentLessonAsync(User.Identity.Name) || id < 1)
                return RedirectToPage("Lessons");
            Progress = await _userManager.GetProgressAsync(User.Identity.Name);
            if(!Progress.WordsComplete)
                return RedirectToPage("LessonTask", "Main");
            Id = id;
            return RedirectToPage("LessonGrammar");
        }
        public async Task<IActionResult> OnPostExerciseAsync(int id)
        {
            if (id > await _userManager.GetCurrentLessonAsync(User.Identity.Name) || id < 1)
                return RedirectToPage("Lessons");
            if (!Progress.WordsComplete||!Progress.GrammarComplete)
                return RedirectToPage("LessonTask","Main");
            Id = id;
            Progress = await _userManager.GetProgressAsync(User.Identity.Name);
            return RedirectToPage("LessonExercise");
        }
    }
}
