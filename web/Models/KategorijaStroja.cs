using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace web.Models
{
    public class KategorijaStroja
    {
        [Key]
        public int MachineTypeID { get; set; }

        
        public string MachineType { get; set; } = string.Empty;
    }
}