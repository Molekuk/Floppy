using Floppy.Models;
using Floppy.Models.LessonModels;
using Floppy.Models.WordModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Floppy.Managers.Lessons
{
    public class LessonManager : ILessonManager
    {
        private readonly ApplicationContext _context;
        public LessonManager(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseExample>> GetExercisesAsync(int lessonId)
        {
            var lesson = await _context.Lessons.Include(l => l.Exercise).FirstOrDefaultAsync(l => l.Id == lessonId);
            var exerciseId = lesson.Exercise.Id;
            return (await _context.Exercises.Include(g => g.Examples).FirstOrDefaultAsync(g => g.Id == exerciseId)).Examples;
        }

        public async Task<IEnumerable<GrammarExample>> GetGrammarsAsync(int lessonId)
        {
            var lesson = await _context.Lessons.Include(l => l.Grammar).FirstOrDefaultAsync(l => l.Id == lessonId);
            var grammarId = lesson.Grammar.Id;
            return (await _context.Grammars.Include(g => g.Examples).FirstOrDefaultAsync(g => g.Id == grammarId)).Examples;
        }

        public async Task<IEnumerable<Word>> GetWordsAsync(int lessonId)
        {
           var lesson = await _context.Lessons.Include(l=>l.WordSet).FirstOrDefaultAsync(l=>l.Id==lessonId);
           var wordsetId = lesson.WordSet.Id;
            return (await _context.WordSets.Include(w => w.Words).FirstOrDefaultAsync(w => w.Id == wordsetId)).Words;
        }

        public async Task LearnExerciseAsync(string username)
        {
            var user = await _context.Users.Include(u => u.Progress).FirstOrDefaultAsync(u => u.UserName == username);
            user.Progress.ExerciseComplete = true;
            await _context.SaveChangesAsync();
        }

        public async Task LearnGrammarAsync(string username)
        {
            var user = await _context.Users.Include(u => u.Progress).FirstOrDefaultAsync(u => u.UserName == username);
            user.Progress.GrammarComplete = true;
            await _context.SaveChangesAsync();
        }

        public async Task LearnWordsAsync(string username)
        {
            var user  = await _context.Users.Include(u=>u.Progress).FirstOrDefaultAsync(u => u.UserName == username);
            user.Progress.WordsComplete = true;
            await _context.SaveChangesAsync();
        }
    }
}
