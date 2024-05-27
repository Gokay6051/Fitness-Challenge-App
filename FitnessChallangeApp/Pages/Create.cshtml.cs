using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using FitnessChallengeApp.Data;
using FitnessChallengeApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace FitnessChallangeApp.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Challenge Challenge { get; set; }

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

            _context.Challenges.Add(Challenge);
            await _context.SaveChangesAsync();

            //return Content("asd");
            return RedirectToPage("./Index");
        }
    }
}
