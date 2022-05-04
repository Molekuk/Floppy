using Floppy.Managers.Stories;
using Floppy.Managers.Users;
using Floppy.Models.StoryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Floppy.Pages
{
    public class StoreModel : PageModel
    {
        public IEnumerable<Story> Stories { get; set; }
        public int Balance { get; set; }
        private readonly IStoryManager _storyManager;
        private readonly IUserManager _userManager;
        public StoreModel(IStoryManager storyManager,IUserManager userManager)
        {
            _storyManager = storyManager;
            _userManager = userManager;
        }

        public async Task OnGetStories()
        {
          Balance = await _userManager.GetBalanceAsync(User.Identity.Name);
          Stories = await _storyManager.GetCurrentStoriesAsync(User.Identity.Name);
        }

        public async Task OnGetWords()
        {
            Balance = await _userManager.GetBalanceAsync(User.Identity.Name);
            Stories = await _storyManager.GetCurrentStoriesAsync(User.Identity.Name);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            await _storyManager.BuyStoryAsync(User.Identity.Name, id);
            return RedirectToPage("Store","Stories",null);
        }
    }
}
