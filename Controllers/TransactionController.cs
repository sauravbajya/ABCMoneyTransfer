using ABCMoneyTransfer.Data;
using ABCMoneyTransfer.Models;
using ABCMoneyTransfer.Services;
using ABCMoneyTransfer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Transactions;

namespace ABCMoneyTransfer.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ExchangeRateService _exchangeRateService;

        public TransactionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ExchangeRateService exchangeRateService)
        {
            _context = context;
            _userManager = userManager;
            _exchangeRateService = exchangeRateService;
        }

        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            var transactions = _context.Transactions.Include(t => t.Sender).OrderByDescending(x => x.Date).AsQueryable();

            if (startDate.HasValue)
            {
                transactions = transactions.Where(t => t.Date.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                transactions = transactions.Where(t => t.Date.Date <= endDate.Value);
            }

            var model = new TransactionFilterViewModel
            {
                Transactions = await transactions.ToListAsync(),
                StartDate = startDate,
                EndDate = endDate
            };


            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            Guid senderId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var exchangeRate = await _exchangeRateService.GetExchangeRateAsync("MYR");

            var model = new TransactionDetail
            {
                SenderId = senderId.ToString(),
                ExchangeRate = exchangeRate ?? 0
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionDetail transaction)
        {
            if (ModelState.IsValid)
            {
                var sender = await _userManager.GetUserAsync(User);
                var exchangeRate = await _exchangeRateService.GetExchangeRateAsync("MYR");

                if (sender == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                if(exchangeRate == null || exchangeRate == 0)
                {
                    ModelState.AddModelError(string.Empty, "Unable to retrieve a valid exchange rate. Please try again later.");
                    return View(transaction);
                }



                transaction.SenderId = sender.Id;

                transaction.ExchangeRate = (int)exchangeRate;

                // Calculate the payout amount in NPR
                transaction.PayoutAmountNPR = transaction.TransferAmountMYR * transaction.ExchangeRate;

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(transaction);
        }
    }
}
