using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NovaCoop.ComputeInterest.API.Controllers
{
    [ApiController]
    public class InterestCalculationController : ControllerBase
    {
        private static readonly HttpClient Client = new HttpClient();

        [HttpGet("/calculajuros")]
        public async Task<IActionResult> InterestCalculation([FromQuery] decimal valorinicial, double meses)
        {
            using var client = new System.Net.Http.HttpClient();
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:55002/taxaJuros");
                var response = await client.SendAsync(request);
                return Ok(await response.Content.ReadAsStringAsync());
            }


            decimal finalValue;
            try
            {
                var response = await Client.GetAsync("https://localhost:55002/taxaJuros");
                var responseBody = await response.Content.ReadAsStringAsync();
                double.TryParse(responseBody, out var feeRate);
                finalValue = decimal.Multiply(valorinicial, (decimal)Math.Pow((1 + feeRate), meses));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok(finalValue);
        }
    }
}
