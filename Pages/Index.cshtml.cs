using EvenimenteSportive.Models;
using EvenimenteSportive.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly EvenimenteContext _context;

    public IndexModel(EvenimenteContext context)
    {
        _context = context;
    }

    public List<RezumatViewModel> Rezumat { get; set; }

    public async Task OnGetAsync()
    {
        Rezumat = await _context.EvenimenteSportive
            .Include(e => e.Locatie)
            .Include(e => e.Participanti)
            .Include(e => e.Sponsori)
            .Select(e => new RezumatViewModel
            {
                EvenimentNume = e.Nume,
                EvenimentData = e.Data,
                LocatieNume = e.Locatie.Nume,
                LocatieCapacitate = e.Locatie.Capacitate,
                Participanti = e.Participanti.Select(p => p.Nume).ToList(),
                Sponsori = e.Sponsori.Select(s => s.Nume).ToList()
            })
            .ToListAsync();
    }
}
