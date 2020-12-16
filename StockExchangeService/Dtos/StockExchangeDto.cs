using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeService.Dtos
{
    public class StockExchangeDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Excahnge Name is required")]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Remarks { get; set; }
    }
}
