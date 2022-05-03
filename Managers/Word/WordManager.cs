using Floppy.Models;
using Floppy.Models.UserModels;
using Floppy.Models.WordModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Floppy.Managers.Words
{
    public class WordManager:IWordManager
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext _context;
        public WordManager(UserManager<User> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IEnumerable<Word>> GetCurrentWordsAsync(string username)
        {
           var user = await _userManager.FindByNameAsync(username);
            return user.CurrentWords;
        }

        public async Task<IEnumerable<Word>> GetLearnedWordsAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user.LearnedWords;
        }

        public async Task<IEnumerable<WordSet>> GetWordSetsAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user.NotPurcharedWordSets;
        }

        public async Task LearnWordAsync(string username, int id)
        {
            var user = await _userManager.FindByNameAsync(username);
            var word = await _context.Words.FindAsync(id);
            var currWords = user.CurrentWords;
            var learnWords = user.LearnedWords;
            currWords.Remove(word);
            learnWords.Add(word);
        }

        public async Task BuyWordSetAsync(string username, int id)
        {
            var user = await _userManager.FindByNameAsync(username);
            var wordSets = user.NotPurcharedWordSets;
            var wordSet = await _context.WordSets.FindAsync(id);
            wordSets.Remove(wordSet);
            user.Money -= wordSet.Price;
        }
    }
}
