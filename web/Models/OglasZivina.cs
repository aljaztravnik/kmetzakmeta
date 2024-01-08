using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class OglasZivina
    {
        [Key]
        public int ZivinaOglasID { get; set; }
        
        public string Title { get; set; } = string.Empty;

        public int Price { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public string? Sex { get; set; }

        public string? Desc { get; set; }

        public int Offspring { get; set; }

        public string? Construction { get; set; }

        public ApplicationUser? User { get; set; }

        public Regija? Region { get; set; }

        public Pasma? Breed { get; set; }
    }
}