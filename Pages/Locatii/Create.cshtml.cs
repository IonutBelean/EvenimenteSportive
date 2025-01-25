using EvenimenteSportive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EvenimenteSportive.Pages.Locatii
{
    public class CreateModel : PageModel
    {
        private readonly EvenimenteContext _context;

        public CreateModel(EvenimenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Locatie Locatie { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Locatii.Add(Locatie);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "A aparut o problema la salvarea locatiei.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
