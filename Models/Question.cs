using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizAppApi.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int OrderNumber { get; set; }

        public ICollection<AnswerChoice> AnswerChoices { get; set; } = new List<AnswerChoice>();
        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}
