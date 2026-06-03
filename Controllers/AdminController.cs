using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Dashboard()
        {
            ViewBag.TotalMembers = _context.Members.Count();
            ViewBag.TotalTrainers = _context.Trainers.Count();
            ViewBag.TotalPayments = _context.Payments.Count();
            return View();
        }
        // LOGIN PAGE
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "1234")
            {
                HttpContext.Session.SetString("Admin", "true");
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid Login!";
            return View();
        }

        // DASHBOARD (PROTECTED)
        public IActionResult Dashboard1()
        {
            if (HttpContext.Session.GetString("Admin") != "true")
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        // LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
