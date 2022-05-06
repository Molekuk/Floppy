using Floppy.Models.WordModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Floppy.Managers.Lessons
{
    public interface ILessonManager
    {
        Task<IEnumerable<Word>> GetWordsAsync(int lessonId);
    }
}
