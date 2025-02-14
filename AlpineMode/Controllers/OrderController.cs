using AlpineMode.Models;
using TodoList;
using TodoList.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OrderController : Controller
{
    private readonly TodoListContext _context;

    public OrderController(TodoListContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Завантажуємо замовлення з клієнтами та турами
        var orders = await _context.Orders.Include(o => o.Client).Include(o => o.Tour).ToListAsync();
        // Перевіряємо чи є замовлення і передаємо їх в представлення
        return View(orders);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return NotFound();

        var model = new OrderViewModel
        {
            ID = order.ID,
            ClientID = order.ClientID,
            TourID = order.TourID,
            Data = order.Data,
            Clients = await _context.Clients.ToListAsync(),
            Tours = await _context.Tours.ToListAsync()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(OrderViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Clients = await _context.Clients.ToListAsync();
            model.Tours = await _context.Tours.ToListAsync();
            return View(model);
        }

        var order = await _context.Orders.FindAsync(model.ID);
        if (order == null) return NotFound();

        order.ClientID = model.ClientID;
        order.TourID = model.TourID;
        order.Data = model.Data;

        _context.Update(order);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var order = await _context.Orders.Include(o => o.Client).Include(o => o.Tour).FirstOrDefaultAsync(o => o.ID == id);
        if (order == null) return NotFound();
        return View(order);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var order = await _context.Orders.Include(o => o.Client).Include(o => o.Tour).FirstOrDefaultAsync(o => o.ID == id);
        if (order == null) return NotFound();
        return View(order);
    }
}
