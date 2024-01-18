using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunNetCoreWeb.Data;
using RunNetCoreWeb.Models;

namespace RunNetCoreWeb
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Race> races = _context.Races.ToList();
            return View(races);
        }

        public IActionResult Detail(int id)
        {
            Race race = _context.Races.Include(a => a.Address).Where(x => x.Id == id).FirstOrDefault();
            return View(race);
        }
    }
}


