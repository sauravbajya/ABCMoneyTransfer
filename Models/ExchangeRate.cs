namespace ABCMoneyTransfer.Models
{
    public class ExchangeRate
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public int Unit { get; set; }
        public decimal BuyRate { get; set; }
        public decimal SellRate { get; set; }
        public bool IsActive { get; set; }
    }
}
