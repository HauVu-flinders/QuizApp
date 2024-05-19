using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.Data
{
    public class QuizAppDbContext : DbContext
    {
        public QuizAppDbContext (DbContextOptions<QuizAppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many relationships
            modelBuilder.Entity<Quiz>()
                .HasMany(e => e.Questions)
                .WithOne(e => e.Quiz)
                .HasForeignKey(e => e.QuizId)
                .HasPrincipalKey(e => e.Id);
            
            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithOne(e => e.Question)
                .HasForeignKey(e => e.QuestionId)
                .HasPrincipalKey(e => e.Id);

            //optional one to one relationship
            modelBuilder.Entity<Answer>()
                .HasOne(e => e.AnswerKey)
                .WithOne(e => e.Answer)
                .HasForeignKey<AnswerKey>(e => e.AnswerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
         
            //seed Quiz
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    Title = "Vocabulary Quiz",
                    Description = "Participate in our straightforward vocab quiz. Explore new words, enjoy learning, and elevate your language proficiency quickly",
                    ImageUrl = "/img/img1.png"
                },
                new Quiz
                {
                    Id = 2,
                    Title = "Grammar Quiz",
                    Description = "Sharpen grammar skills with our quick quiz! From punctuation to sentence structure, boost your language precision in just minutes",
                    ImageUrl = "/img/img2.png"
                },
                new Quiz
                {
                    Id = 3,
                    Title = "Pronunciation Quiz",
                    Description = "Improve pronunciation with our quick guide! Learn correct speech sounds and refine your speaking skills effortlessly",
                    ImageUrl = "/img/img3.png"
                }
                );
        }
        public DbSet<QuizApp.Models.Question> Questions { get; set; }
        public DbSet<QuizApp.Models.Quiz> Quizzes {  get; set; }
        public DbSet<QuizApp.Models.Answer> Answers { get; set;}
        public DbSet<QuizApp.Models.AnswerKey> AnswersKeys { get; set;}
    }
}
