using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SectorService.Entities
{
    public class StockPrice
    {
        public int ID { get; set; }
        public string StockExchange { get; set; }

        public float Price { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Company")]
        public string CompanyCode { get; set; }

        public Company Company { get; set; }
    }
}
