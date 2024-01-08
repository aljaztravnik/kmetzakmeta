using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class OglasStroj
    {
        [Key]
        public int StrojOglasID { get; set; }
        
        public string Title { get; set; } = string.Empty;

        public int Price { get; set; }

        public int Age { get; set; }

        public int WorkingHours { get; set; }

        public int Power { get; set; }

        public string? Desc { get; set; }

        public ApplicationUser? User { get; set; }

        public Regija? Region { get; set; }

        public Znamka? Brand { get; set; }

        public KategorijaStroja? Category { get; set; }
    }
}