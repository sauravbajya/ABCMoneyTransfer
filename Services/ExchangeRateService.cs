using ABCMoneyTransfer.Models;
using Newtonsoft.Json.Linq;

namespace ABCMoneyTransfer.Services
{
    public class ExchangeRateService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://www.nrb.org.np/api/forex/v1/rates?page=1&per_page=5&from=2024-06-12&to=2024-06-12";

        public ExchangeRateService(HttpClient httpClient)
        {
             _httpClient = httpClient;
        }

        public async Task<List<ExchangeRate>> GetExchangeRatesAsync()
        {
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            var apiUrl = $"https://www.nrb.org.np/api/forex/v1/rates?page=1&per_page=5&from={today}&to={today}";

            var response = await _httpClient.GetStringAsync(apiUrl);
            var data = JObject.Parse(response);
            var rates = data["data"]["payload"][0]["rates"];
            
            var exchangeRates = new List<ExchangeRate>();

            foreach(var rate in rates)
            {
                exchangeRates.Add(new ExchangeRate
                {
                    CurrencyCode = rate["currency"]["iso3"].ToString(),
                    CurrencyName = rate["currency"]["name"].ToString(),
                    Unit = (int)rate["currency"]["unit"],
                    BuyRate = rate["buy"].Value<decimal>(),
                    SellRate = rate["sell"].Value<decimal>()
                });
            }
            return exchangeRates;
        }
        public async Task<decimal?> GetExchangeRateAsync(string currencyIso)
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);
            var data = JObject.Parse(response);
            var rates = data["data"]["payload"][0]["rates"];

            foreach (var rate in rates)
            {
                var iso3 = rate["currency"]["iso3"].ToString();
                if (iso3 == currencyIso)
                {
                    return rate["sell"].Value<decimal>();
                }
            }

            return null;
        }
    }
}
