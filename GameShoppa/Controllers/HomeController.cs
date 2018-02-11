using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameShoppa.Data;
using GameShoppa.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShoppa.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return View(await _context.Game.Include(g => g.Genre).ToListAsync());
            }

            var game = await _context.Game
                .Include(g => g.Genre)
                .Where(m => m.Genre.ID == id)
                .ToListAsync();
                

            return View(game);
        }

        public async Task<IActionResult> Game(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Genre)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
