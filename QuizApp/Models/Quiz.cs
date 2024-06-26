﻿namespace QuizApp.Models
{
    public class Quiz
    {
     
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
