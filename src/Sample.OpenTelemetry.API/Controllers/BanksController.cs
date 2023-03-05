using Microsoft.AspNetCore.Mvc;
using Sample.OpenTelemetry.Core.Services;

namespace open_telemetry_jaeger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BanksController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var banks = await _bankService.ListBanksAsync();
            return Ok(banks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bank = await _bankService.GetBankAsync(id);

            if (bank is null)
                return BadRequest($"Error trying to find bank with the ID {id}. Please try again.");

            return Ok(bank);
        }
    }
}
