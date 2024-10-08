using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BizLinkk.Data;

namespace BizLinkk.Controllers
{
    public class PartnersController : Controller
    {
        private readonly PrakseContext _context;
        public PartnersController(PrakseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Get the total number of records
            var partners = await _context.Partners.ToListAsync();
            return View(partners);
        }
    }
}