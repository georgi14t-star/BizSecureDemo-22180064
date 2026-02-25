using System.Security.Claims;
using BizSecureDemo_22180064.ViewModels;
using BizSecureDemo22180064.Data;
using BizSecureDemo22180064.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BizSecureDemo_22180064.Controllers
{
    
    public class OrdersController : Controller
    {
        private readonly AppDbContext _db;
        public OrdersController(AppDbContext db) => _db = db;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderVm vm)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Home");

            var uid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            _db.Orders.Add(new Order
            {
                UserId = uid,
                Title = vm.Title,
                Amount = vm.Amount
            });

            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Details(int id)
        {
            var uid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            // Обърнете внимание


            var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id && o.UserId == uid); //кой вижда
            if (order == null) return Forbid();
            return View(order);

            // Обърнете внимание: търсим само по Id, без проверка за собственост
            //public async Task<IActionResult> Details(int id)
            //{
            // Обърнете внимание: търсим само по Id, без проверка за собственост
            // var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);
            // if (order == null) return NotFound();
            //return View(order);
        }

            
        
    }

}
