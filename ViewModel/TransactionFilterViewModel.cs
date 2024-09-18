using ABCMoneyTransfer.Models;

namespace ABCMoneyTransfer.ViewModel
{
    public class TransactionFilterViewModel
    {
        public IEnumerable<TransactionDetail> Transactions { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
