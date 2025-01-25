using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Participanti
{
    public class EditModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public EditModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participant Participant { get; set; }
        public IList<EvenimentSportiv> EvenimenteSportive { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Participant = await _context.Participanti
                .Include(p => p.EvenimentSportiv)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (Participant == null)
            {
                return NotFound();
            }

            EvenimenteSportive = await _context.EvenimenteSportive.ToListAsync();
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

            var participantInDb = await _context.Participanti.FirstOrDefaultAsync(p => p.ID == Participant.ID);
            if (participantInDb == null)
            {
                return NotFound();
            }

            participantInDb.Nume = Participant.Nume;
            participantInDb.Varsta = Participant.Varsta;
            participantInDb.Echipa = Participant.Echipa;
            participantInDb.IDEveniment = Participant.IDEveniment;

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
