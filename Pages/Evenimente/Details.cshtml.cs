using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvenimenteSportive.Models;

namespace EvenimenteSportive.Pages.Evenimente
{
    public class DetailsModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public DetailsModel(EvenimenteContext context)
        {
            _context = context;
        }

        public EvenimentSportiv EvenimentSportiv { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenimentsportiv = await _context.EvenimenteSportive.FirstOrDefaultAsync(m => m.ID == id);
            if (evenimentsportiv == null)
            {
                return NotFound();
            }
            else
            {
                EvenimentSportiv = evenimentsportiv;
            }
            return Page();
        }
    }
}
