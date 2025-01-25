using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EvenimenteSportive.Pages.Sponsori
{
    public class DeleteModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public DeleteModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sponsor Sponsor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sponsor = await _context.Sponsori.FirstOrDefaultAsync(m => m.ID == id);

            if (Sponsor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sponsor = await _context.Sponsori.FindAsync(id);

            if (Sponsor != null)
            {
                _context.Sponsori.Remove(Sponsor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
