using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Sponsori
{
    public class IndexModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public IndexModel(EvenimenteContext context)
        {
            _context = context;
        }

        public IList<Sponsor> Sponsori { get; set; }

        public async Task OnGetAsync()
        {
            Sponsori = await _context.Sponsori.Include(s => s.EvenimentSportiv).ToListAsync();
        }
    }
}
