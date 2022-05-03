namespace Floppy.Models.WordModels
{
    public class Word
    {
        public int Id { get; set; } 
        public string Image { get; set; }
        public string Name { get; set; }
        public string Translation { get; set; }
        public string Sentence { get; set; }
        public WordSet WordSet { get; set; }
    }
}
