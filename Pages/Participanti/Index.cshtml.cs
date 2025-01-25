using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Participanti
{
    public class IndexModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public IndexModel(EvenimenteContext context)
        {
            _context = context;
        }
        public IList<Participant> Participanti { get; set; }

        public async Task OnGetAsync()
        {
            Participanti = await _context.Participanti.Include(p => p.EvenimentSportiv).ToListAsync();
        }
    }
}
