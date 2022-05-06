using Floppy.Managers.Lessons;
using Floppy.Models.WordModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floppy.Pages
{
    public class LessonWordsModel : PageModel
    {
        public IEnumerable<Word> Words { get; set; }
        public int LessonId { get; set; }
        public int Count { get; set; }
        private readonly ILessonManager _lessonManager;
        public LessonWordsModel(ILessonManager lessonManager)
        {
            _lessonManager = lessonManager;
        }
        public async Task OnPost(int lessonId)
        {
            Words = await _lessonManager.GetWordsAsync(lessonId);
            LessonId = lessonId;
            Count = Words.Count();
        }

        public async Task<IActionResult> OnPostComplete(int lessonId)
        {
            return RedirectToPage("LessonTask", new {id=lessonId});
        }
    }
}
