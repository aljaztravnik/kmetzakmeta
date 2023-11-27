using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Uporabnik
    {
        [Key]
        public int UserID { get; set; }
        
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }

        public Regija? Region { get; set; }
    }
}