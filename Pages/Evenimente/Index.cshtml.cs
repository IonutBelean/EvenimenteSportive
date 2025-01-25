using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Evenimente
{
    public class IndexModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public IndexModel(EvenimenteContext context)
        {
            _context = context;
        }

        public IList<EvenimentSportiv> Evenimente { get; set; }

        public async Task OnGetAsync()
        {
            Evenimente = await _context.EvenimenteSportive.Include(e => e.Locatie).ToListAsync();
        }
    }
}
