﻿namespace Floppy.Models.LessonModels
{
    public class ExerciseExample
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int CorrectAnswer { get; set; }
        public Exercise Exercise { get; set; }
    }
}
