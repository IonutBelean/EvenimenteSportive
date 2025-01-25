using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Evenimente
{
    public class CreateModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public CreateModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EvenimentSportiv EvenimentSportiv { get; set; }
        public IList<Locatie> Locatii { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Locatii = await _context.Locatii.ToListAsync();

            if (!Locatii.Any())
            {
                ModelState.AddModelError(string.Empty, "Nu exista locatii disponibile. Adauga locatii inainte de a crea un eveniment.");
            }

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

            _context.EvenimenteSportive.Add(EvenimentSportiv);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "A aparut o problema la salvarea evenimentului.");
                Locatii = await _context.Locatii.ToListAsync();
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
