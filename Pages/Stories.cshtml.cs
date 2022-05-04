using Floppy.Managers.Stories;
using Floppy.Models.StoryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Floppy.Pages
{
    public class StoriesModel : PageModel
    {
        public IEnumerable<Story> Stories { get; set; }
        private readonly IStoryManager _storyManager;
        public StoriesModel(IStoryManager storyManager)
        {
            _storyManager = storyManager;
        }
        public async Task OnGetCurrentAsync()
        {
            Stories = await _storyManager.GetCurrentStoriesAsync(User.Identity.Name);
        }

        public async Task OnGetPurcharedAsync()
        {
            Stories = await _storyManager.GetPurcharedStoriesAsync(User.Identity.Name);
        }

        //public async Task<IActionResult> OnPost(int wordId)
        //{
        //    await _wordManager.LearnWordAsync(User.Identity.Name, wordId);
        //    return RedirectToPage("Dictionary", "Current", null);
        //}
    }
}
