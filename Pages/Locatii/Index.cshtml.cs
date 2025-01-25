using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Locatii
{
    public class IndexModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public IndexModel(EvenimenteContext context)
        {
            _context = context;
        }

        public IList<Locatie> Locatii { get; set; }

        public async Task OnGetAsync()
        {
            Locatii = await _context.Locatii.ToListAsync();
        }
    }
}
