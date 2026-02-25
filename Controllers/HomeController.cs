using System.Diagnostics;
using System.Security.Claims;
using BizSecureDemo_22180064.Models;
using BizSecureDemo22180064.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BizSecureDemo_22180064.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
            
        {
            var uid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!); //Взима ID-то на логнатия потребител

            var myOrders = await _db.Orders
                .Where(o => o.UserId == uid)
                .OrderByDescending(o => o.Id)
                .ToListAsync(); // Чете поръчките от базата спрямо логнатия потребител

            var allOrders = await _db.Orders
                .OrderByDescending(o => o.Id)
                .ToListAsync(); // Чете всички поръчки от базата

            ViewBag.AllOrders = allOrders; //Подава всички поръчки към View-то през ViewBag. ViewBag е „чанта“ за допълнителни данни към View-то. Така View-то може да показва и публичен списък от поръчки.
            return View(myOrders);
        }

        //{
        //    var uid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        //    var orders = await _db.Orders
        //        .Where(o => o.UserId == uid)
        //        .OrderByDescending(o => o.Id)
        //        .ToListAsync();

        //    return View(orders);
        //}
    }
}