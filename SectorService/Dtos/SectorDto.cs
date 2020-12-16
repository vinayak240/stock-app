using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Dtos
{
    public class SectorDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Sector name is required")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
