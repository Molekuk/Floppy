using Floppy.Models.WordModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Floppy.Pages
{
    public class DictionaryModel : PageModel
    {
        public ICollection<Word> Words { get; set; }=new List<Word>();
        public void OnGetCurrent()
        {
            Word word1 = new Word() { Name = "Яблоко", Translation = "Apple", Sentence = "I like apple" };
            Word word2 = new Word() { Name = "Машина", Translation = "Car", Sentence = "I like car" };
            Word word3 = new Word() { Name = "Апельсин", Translation = "Orange", Sentence = "I like orange" };

            Words.Add(word1);
            Words.Add(word2);
            Words.Add(word3);

        }

        public void OnGetLearned()
        {
            Word word = new Word() { Name = "Яблоко", Translation = "Apple", Sentence = "I like apple" };
            Words.Add(word);
        }
    }
}
