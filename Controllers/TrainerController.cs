using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;


namespace WebApplication1.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Trainers.ToList());
       
        }
    }
}
