using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EvenimenteSportive.Pages.Sponsori
{
    public class DetailsModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public DetailsModel(EvenimenteContext context)
        {
            _context = context;
        }

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
    }
}
