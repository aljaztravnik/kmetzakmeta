using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Znamka
    {
        [Key]
        public int BrandID { get; set; }
        
        public string Name { get; set; } = string.Empty;
    }
}