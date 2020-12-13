using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace StockExchangeService.Entities
{
    public class Company
    {
        [Key]
        public string CompanyCode { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public string StockExchanges { get; set; }
    }
}
