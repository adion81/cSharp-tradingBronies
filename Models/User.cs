using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradingBronies.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password {get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<Brony> MyLittleBronies { get; set; }


    }
}