using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Models
{
    public class AnswerChoice
    {
        [Key]
        public int AnswerChoiceId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public bool IsCorrect { get; set; }

        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }
        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}
