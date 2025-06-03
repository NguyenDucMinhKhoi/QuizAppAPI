using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizAppApi.Models
{
    public class User
    {
        public User()
        {
            QuizSessions = new List<QuizSession>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Password { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<QuizSession> QuizSessions { get; set; }
    }
}
