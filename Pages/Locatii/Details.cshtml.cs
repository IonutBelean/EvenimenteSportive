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
    public class DetailsModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public DetailsModel(EvenimenteContext context)
        {
            _context = context;
        }

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
    }
}
