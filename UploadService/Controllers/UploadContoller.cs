using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompanyApiClient;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UploadService.Controllers
{
    [Route("api.upload/upload")]
    [ApiController]
    public class UploadContoller : ControllerBase
    {

        // POST api/<UploadContoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StockPriceDto[] stocks)
        {
            var companyClient = new CompanyApiClient.CompanyApiClient();

            var sectorClient = new SectorApiClient.SectorApiClient();

            //companyClient.StockAsync()
            foreach (var stk in stocks)
            {
                var stk1 = new SectorApiClient.StockPrice()
                {
                    CompanyCode = stk.CompanyCode,
                    Date = stk.Date,
                    Price = stk.Price,
                    StockExchange = stk.StockExchange,
                    Id = stk.Id
                };
               await companyClient.StockAsync(stk);
               await sectorClient.StockAsync(stk1);


            }
            return Ok();
        }
    }
}
