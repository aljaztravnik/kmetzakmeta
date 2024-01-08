using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Pasma
    {
        [Key]
        public int BreedID { get; set; }
        
        public string Breed { get; set; } = string.Empty;
    }
}