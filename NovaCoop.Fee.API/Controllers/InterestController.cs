using Microsoft.AspNetCore.Mvc;

namespace NovaCoop.Fee.API.Controllers
{
    [ApiController]
    public class InterestController : ControllerBase
    {
        [HttpGet("taxaJuros")]
        public IActionResult GetInterestRate()
        {
            return Ok(new decimal(0.01));
        }
    }
}
