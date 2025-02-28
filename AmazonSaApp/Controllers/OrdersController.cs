using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System;

[Route("Orders")] // تحديد المسار الأساسي للمتحكم
public class OrdersController : Controller
{
    private static List<Order> orders = new List<Order>();

    // عرض نموذج تقديم الطلب (GET)
    [HttpGet("Create")]
    public IActionResult Create(int productId)
    {
        var order = new Order();
        return View(order);
    }

    // استقبال الطلب ومعالجته (POST)
    [HttpPost("Create")]
    public IActionResult Create([FromForm] Order order)
    {
        if (!ModelState.IsValid)
        {
            return View(order); // إعادة النموذج مع الأخطاء إن وجدت
        }

        order.Id = orders.Count + 1;
        order.OrderDate = DateTime.Now;
        orders.Add(order);

        return RedirectToAction("History", new { userId = order.UserId });
    }

    // جلب سجل الطلبات للمستخدم (GET)
    [HttpGet("{userId}")]
    public IActionResult History(int userId)
    {
        var userOrders = orders.Where(o => o.UserId == userId).ToList();
        return View(userOrders);
    }
}
