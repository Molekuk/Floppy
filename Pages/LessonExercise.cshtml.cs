using Floppy.Managers.Lessons;
using Floppy.Managers.Users;
using Floppy.Models.LessonModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floppy.Pages
{
    public class LessonExerciseModel : PageModel
    {
        public IEnumerable<ExerciseExample> Exercises { get; set; }
        public int LessonId { get; set; }
        public int Count { get; set; }
        private readonly ILessonManager _lessonManager;
        private readonly IUserManager _userManager;
        public LessonExerciseModel(ILessonManager lessonManager, IUserManager userManager)
        {
            _lessonManager = lessonManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnPost(int lessonId)
        {
            var progress = await _userManager.GetProgressAsync(User.Identity.Name);
            if (!progress.WordsComplete)
                return RedirectToPage("Lessons");

            Exercises = await _lessonManager.GetExercisesAsync(lessonId);
            LessonId = lessonId;
            Count = Exercises.Count();
            return Page();
        }

        public async Task<IActionResult> OnPostComplete(int lessonId,int correctanswers)
        {
            if (lessonId > await _userManager.GetCurrentLessonAsync(User.Identity.Name) || lessonId < 1||correctanswers>4||correctanswers<0)
                return RedirectToPage("Lessons");
            await _lessonManager.LearnExerciseAsync(User.Identity.Name);
            return RedirectToPage("LessonTask", new { id = lessonId });
        }
    }
}
