using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Locatii
{
    public class EditModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public EditModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Locatie Locatie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Locatie = await _context.Locatii.FirstOrDefaultAsync(l => l.ID == id);

            if (Locatie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var locatieInDb = await _context.Locatii.FirstOrDefaultAsync(l => l.ID == Locatie.ID);
            if (locatieInDb == null)
            {
                return NotFound();
            }

            locatieInDb.Nume = Locatie.Nume;
            locatieInDb.Adresa = Locatie.Adresa;
            locatieInDb.Capacitate = Locatie.Capacitate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "A aparut o problema la salvarea modificarilor.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
