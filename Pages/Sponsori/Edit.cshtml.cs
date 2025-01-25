using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Sponsori
{
    public class EditModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public EditModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sponsor Sponsor { get; set; }
        public IList<EvenimentSportiv> EvenimenteSportive { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Sponsor = await _context.Sponsori
                .Include(s => s.EvenimentSportiv)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (Sponsor == null)
            {
                return NotFound();
            }

            EvenimenteSportive = await _context.EvenimenteSportive.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Sponsor.EvenimentSportiv");

            if (!ModelState.IsValid)
            {
                EvenimenteSportive = await _context.EvenimenteSportive.ToListAsync();
                return Page();
            }

            var sponsorInDb = await _context.Sponsori.FirstOrDefaultAsync(s => s.ID == Sponsor.ID);
            if (sponsorInDb == null)
            {
                return NotFound();
            }

            sponsorInDb.Nume = Sponsor.Nume;
            sponsorInDb.Buget = Sponsor.Buget;
            sponsorInDb.DurataContract = Sponsor.DurataContract;
            sponsorInDb.IDEveniment = Sponsor.IDEveniment;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "A aparut o problema la salvarea modificarilor.");
                EvenimenteSportive = await _context.EvenimenteSportive.ToListAsync();
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
