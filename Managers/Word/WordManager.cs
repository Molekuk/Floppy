using Floppy.Models;
using Floppy.Models.UserModels;
using Floppy.Models.WordModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
           return _context.UserWords.Where(w=>w.UserId==user.Id).Where(w=>w.Learned==false).Select(w=>w.Word);
        }

        public async Task<IEnumerable<Word>> GetLearnedWordsAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return _context.UserWords.Where(w => w.UserId == user.Id).Where(w => w.Learned == true).Select(w => w.Word);
        }

       //public async Task<IEnumerable<WordSet>> GetWordSetsAsync(string username)
       //{
       //    var user = await _userManager.FindByNameAsync(username);
       //    return user;
       //}

        public async Task LearnWordAsync(string username, int id)
        {
            var user = await _userManager.FindByNameAsync(username);
            var word = _context.UserWords.FirstOrDefault(w => w.UserId == user.Id && w.Id == id);
            word.Learned = true;
            await _context.SaveChangesAsync();
        }

        public Task BuyWordSetAsync(string username, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
