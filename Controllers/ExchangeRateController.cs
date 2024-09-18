using ABCMoneyTransfer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ABCMoneyTransfer.Controllers
{
    public class ExchangeRateController : Controller
    {
        private readonly ExchangeRateService _exchangeRateService;

        public ExchangeRateController(ExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }
        public async Task<IActionResult> Index()
        {
            var exchangeRates = await _exchangeRateService.GetExchangeRatesAsync();
            return View(exchangeRates);
        }
    }
}
