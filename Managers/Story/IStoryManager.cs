using Floppy.Models.StoryModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Floppy.Managers.Stories
{
    public interface IStoryManager
    {
       Task<IEnumerable<Story>> GetCurrentStoriesAsync(string username);
       Task<IEnumerable<Story>> GetPurcharedStoriesAsync(string username);
       Task<Story> GetStoryAsync(int id);
       Task BuyStoryAsync(string username, int id);
    }
}
