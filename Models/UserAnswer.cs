using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Models
{
    public class UserAnswer
    {
        [Key]
        public int UserAnswerId { get; set; }

        [Required]
        public int QuizSessionId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int SelectedChoiceId { get; set; }

        [Required]
        public DateTime AnsweredAt { get; set; }

        [ForeignKey("QuizSessionId")]
        public QuizSession? QuizSession { get; set; }

        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }

        [ForeignKey("SelectedChoiceId")]
        public AnswerChoice? SelectedChoice { get; set; }
    }
}
