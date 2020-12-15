using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Dtos
{
    public class StockPriceDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Exchange is required")]
        public string StockExchange { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }

        //[Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Company Code is required")]
        public string CompanyCode { get; set; }

    }
}
