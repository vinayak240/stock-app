using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Entities
{
    public class Company
    {
        [Key]
        public string CompanyCode { get; set; } // format "stock-exchange:code"

        public string Name { get; set; }

        public string CEO { get; set; }

        public string BoardOfDirectors { get; set; }

        public float Turnover { get; set; }

        public string Description { get; set; }

        public string StockExchanges { get; set; }

        public string SectorName { get; set; }


    }
}
