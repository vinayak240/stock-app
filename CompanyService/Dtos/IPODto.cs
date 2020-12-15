using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Dtos
{
    public class IPODto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Exchange Name is required")]
        public string StockExchange { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public float PricePerShare { get; set; }

        [Required(ErrorMessage = "No. of shares is required")]
        public int TotalShares { get; set; }

        [Required(ErrorMessage = "Open Date is required")]
        public DateTime OpenDate { get; set; }

        public string Remarks { get; set; }

        [Required(ErrorMessage = "Company code is required")]
        public string CompanyCode { get; set; }
    }
}
