using System.Collections.Generic;

namespace Floppy.Models.WordModels
{
    public class WordSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public bool IsInLesson { get; set; }
        public List<Word> Words { get; set; }
    }
}
