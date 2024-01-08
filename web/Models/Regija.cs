using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Regija
    {
        [Key]
        public int RegionID { get; set; }
        
        public string Region { get; set; } = string.Empty;
    }
}