using Floppy.Models.WordModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Floppy.Managers.Words
{
    public interface IWordManager
    {
        public Task<IEnumerable<Word>> GetCurrentWordsAsync(string username);
        public Task<IEnumerable<Word>> GetLearnedWordsAsync(string username);
        public Task<IEnumerable<WordSet>> GetWordSetsAsync(string username);
        public Task LearnWordAsync(string username, int id);
        public Task BuyWordSetAsync(string username, int id);
    }
}
