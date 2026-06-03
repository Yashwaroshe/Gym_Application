using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        return View(user);
    }

    // ✅ Login GET
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // ✅ Login POST
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Email == email && u.Password == password);

        if (user != null)
        {
            // 👉 Login success
            return Content("Login Successful 🎉");
        }
        else
        {
            ViewBag.Error = "Invalid Email or Password";
            return View();
        }
    }
}