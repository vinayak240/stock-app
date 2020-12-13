using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace CompanyService.Entities
{
    public class IPO
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public string StockExchange { get; set; }

        public float PricePerShare { get; set; }

        public int TotalShares { get; set; }

        public DateTime OpenDate { get; set; }

        public string Remarks { get; set; }

        [ForeignKey("com")]
        public string CompanyCode { get; set; }

        public Company com { get; set; }
    }
}
