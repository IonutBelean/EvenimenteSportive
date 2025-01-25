using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Sponsori
{
    public class CreateModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public CreateModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sponsor Sponsor { get; set; }
        public IList<EvenimentSportiv> EvenimenteSportive { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            EvenimenteSportive = await _context.EvenimenteSportive.ToListAsync();

            if (!EvenimenteSportive.Any())
            {
                ModelState.AddModelError(string.Empty, "Nu există evenimente disponibile. Adaugă evenimente înainte de a crea un sponsor.");
            }

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

            _context.Sponsori.Add(Sponsor);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "A aparut o problema la salvarea sponsorului.");
                EvenimenteSportive = await _context.EvenimenteSportive.ToListAsync();
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
