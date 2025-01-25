using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Evenimente
{
    public class EditModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public EditModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EvenimentSportiv EvenimentSportiv { get; set; }
        public IList<Locatie> Locatii { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            EvenimentSportiv = await _context.EvenimenteSportive
                .Include(e => e.Locatie)
                .FirstOrDefaultAsync(e => e.ID == id);

            if (EvenimentSportiv == null)
            {
                return NotFound();
            }

            Locatii = await _context.Locatii.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("EvenimentSportiv.Locatie");

            if (!ModelState.IsValid)
            {
                Locatii = await _context.Locatii.ToListAsync();
                return Page();
            }

            var evenimentInDb = await _context.EvenimenteSportive.FirstOrDefaultAsync(e => e.ID == EvenimentSportiv.ID);
            if (evenimentInDb == null)
            {
                return NotFound();
            }

            evenimentInDb.Nume = EvenimentSportiv.Nume;
            evenimentInDb.Data = EvenimentSportiv.Data;
            evenimentInDb.Tip = EvenimentSportiv.Tip;
            evenimentInDb.IDLocatie = EvenimentSportiv.IDLocatie;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "A aparut o problema la salvarea modificarilor.");
                Locatii = await _context.Locatii.ToListAsync();
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
