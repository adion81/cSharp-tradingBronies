using System;
using System.ComponentModel.DataAnnotations;

namespace TradingBronies.Models
{
    public class Brony
    {
        [Key]
        public int BronyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required]
        public decimal Price {  get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }

        //NOT stored in database
        public User Owner { get; set;}
    }
}