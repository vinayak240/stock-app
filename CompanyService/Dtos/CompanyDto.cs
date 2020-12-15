using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Dtos
{
    public class CompanyDto
    {
        public string CompanyCode { get; set; }

        [Required(ErrorMessage = "Name is Mandatory")]
        public string Name { get; set; }

        public string CEO { get; set; }

        public string BoardOfDirectors { get; set; }

        public float Turnover { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Alleast One is Mandatory")]
        public string StockExchanges { get; set; }
        [Required(ErrorMessage = " Sector Name is Mandatory")]
        public string SectorName { get; set; }
    }
}
