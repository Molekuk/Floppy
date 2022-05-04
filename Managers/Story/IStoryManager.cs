using Floppy.Models.StoryModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Floppy.Managers.Stories
{
    public interface IStoryManager
    {
        public Task<IEnumerable<Story>> GetCurrentStoriesAsync(string username);
        public Task<IEnumerable<Story>> GetPurcharedStoriesAsync(string username);
        public Task<Story> GetStoryAsync(int id);
        public Task BuyStoryAsync(string username, int id);
    }
}
