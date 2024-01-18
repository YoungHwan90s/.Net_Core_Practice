using Microsoft.AspNetCore.Mvc;
using RunNetCoreWeb.Data;
using RunNetCoreWeb.Models;

namespace RunNetCoreWeb
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Club> clubs = _context.Clubs.ToList();
            return View(clubs);
        }
    }
}


