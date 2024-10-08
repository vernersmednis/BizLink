using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BizLinkk.Data;
using BizLinkk.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BizLinkk.Controllers
{
    public class PartnersController : Controller
    {
        private readonly PrakseContext _context;
        public PartnersController(PrakseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Get the total number of records
            var partners = await _context.Partners.ToListAsync();
            return View(partners);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, RegistrationNo, VatRegNo, Rcoc, Rcoe")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partner);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(partner);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var partner = await _context.Partners.FirstOrDefaultAsync(x => x.PartnerId == id);
            return View(partner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartnerId, Name, RegistrationNo, VatRegNo, Rcoc, Rcoe, Rctc, Rcte")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                _context.Update(partner);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(partner);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var partner = await _context.Partners.FirstOrDefaultAsync(x => x.PartnerId == id);
            return View(partner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Partners.FindAsync(id);
            if (item != null)
            {
                _context.Partners.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}