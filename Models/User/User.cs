using Floppy.Models.WordModels;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace Floppy.Models.UserModels
{
    public class User:IdentityUser
    {
        public int Money { get; set; }
        public int CurrentLesson { get; set; }
        public List<Word> CurrentWords { get; set; }
        public List<Word> LearnedWords { get; set; }
        public List<WordSet> NotPurcharedWordSets { get; set; }
    }
}
