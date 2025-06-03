using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Models
{
    public class QuizSession
    {
        [Key]
        public int QuizSessionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int TotalCorrect { get; set; }

        [Required]
        public int TotalQuestions { get; set; }

        [Required]
        public bool Passed { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}
