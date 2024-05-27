using FitnessChallengeApp.Data;
using FitnessChallengeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FitnessChallangeApp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Challenge Challenge { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Challenge = await _context.Challenges.FindAsync(id);

            if (Challenge == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
