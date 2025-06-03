using QuizAppApi.Models;
using System;
using System.Linq;

namespace QuizAppApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(QuizDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Questions.Any())
                return;

            var questions = new Question[]
            {
                new Question { Content = "In any programming language, what is the most common way to iterate through an array?", OrderNumber = 1 },
                new Question { Content = "What does SQL stand for?", OrderNumber = 2 },
                new Question { Content = "Which keyword is used to define a constant in C#?", OrderNumber = 3 }
            };

            foreach (var q in questions)
            {
                context.Questions.Add(q);
            }
            context.SaveChanges();

            var answerChoices = new AnswerChoice[]
            {
                new AnswerChoice { QuestionId = questions[0].QuestionId, Content = "For loops",     IsCorrect = true  },
                new AnswerChoice { QuestionId = questions[0].QuestionId, Content = "If statements",  IsCorrect = false },
                new AnswerChoice { QuestionId = questions[0].QuestionId, Content = "While loops",   IsCorrect = false },
                new AnswerChoice { QuestionId = questions[0].QuestionId, Content = "Do-while loops",IsCorrect = false },

                new AnswerChoice { QuestionId = questions[1].QuestionId, Content = "Structured Query Language", IsCorrect = true  },
                new AnswerChoice { QuestionId = questions[1].QuestionId, Content = "Sequential Query List",    IsCorrect = false },
                new AnswerChoice { QuestionId = questions[1].QuestionId, Content = "Simple Query Language",      IsCorrect = false },
                new AnswerChoice { QuestionId = questions[1].QuestionId, Content = "None of the above",           IsCorrect = false },

                new AnswerChoice { QuestionId = questions[2].QuestionId, Content = "const",    IsCorrect = true  },
                new AnswerChoice { QuestionId = questions[2].QuestionId, Content = "var",      IsCorrect = false },
                new AnswerChoice { QuestionId = questions[2].QuestionId, Content = "static",   IsCorrect = false },
                new AnswerChoice { QuestionId = questions[2].QuestionId, Content = "readonly", IsCorrect = false }
            };

            foreach (var ac in answerChoices)
            {
                context.AnswerChoices.Add(ac);
            }
            context.SaveChanges();
        }
    }
}
