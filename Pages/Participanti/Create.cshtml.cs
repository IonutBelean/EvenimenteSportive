using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Participanti
{
    public class CreateModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public CreateModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participant Participant { get; set; }
        public IList<EvenimentSportiv> EvenimenteSportive { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            EvenimenteSportive = await _context.EvenimenteSportive.ToListAsync();

            if (!EvenimenteSportive.Any())
            {
                ModelState.AddModelError(string.Empty, "Nu exista evenimente disponibile. Adauga evenimente inainte de a crea un participant.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Participant.EvenimentSportiv");

            if (!ModelState.IsValid)
            {
                EvenimenteSportive = await _context.EvenimenteSportive.ToListAsync();
                return Page();
            }

            _context.Participanti.Add(Participant);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "A aparut o problema la salvarea participantului.");
                EvenimenteSportive = await _context.EvenimenteSportive.ToListAsync();
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
