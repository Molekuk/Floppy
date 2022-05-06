using Floppy.Models;
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
        public async Task<IEnumerable<Word>> GetWordsAsync(int lessonId)
        {
           var lesson = await _context.Lessons.Include(l=>l.WordSet).FirstOrDefaultAsync(l=>l.Id==lessonId);
           var wordsetId = lesson.WordSet.Id;
            return (await _context.WordSets.Include(w => w.Words).FirstOrDefaultAsync(w => w.Id == wordsetId)).Words;
        }
    }
}
