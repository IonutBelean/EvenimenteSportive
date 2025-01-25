using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvenimenteSportive.Models;

namespace EvenimenteSportive.Pages.Locatii
{
    public class DeleteModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public DeleteModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Locatie Locatie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatie = await _context.Locatii.FirstOrDefaultAsync(m => m.ID == id);

            if (locatie == null)
            {
                return NotFound();
            }
            else
            {
                Locatie = locatie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatie = await _context.Locatii.FindAsync(id);
            if (locatie != null)
            {
                Locatie = locatie;
                _context.Locatii.Remove(Locatie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
