using FitnessChallengeApp.Data;
using FitnessChallengeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FitnessChallangeApp.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        //public int _id;
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Challenge Challenge { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            //this._id = id;
            Challenge = await _context.Challenges.FindAsync(id);

            if (Challenge == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Challenge challengeToUpdate = await _context.Challenges.FindAsync(id);
            if (challengeToUpdate == null)
            {
                //return Content("asd");
                //return NotFound();
                return Content($"Belirtilen ID değeri {id} için kayıt bulunamadı.");
            }

            challengeToUpdate.Title = Challenge.Title;
            challengeToUpdate.Description = Challenge.Description;
            challengeToUpdate.Category = Challenge.Category;
            challengeToUpdate.Difficulty = Challenge.Difficulty;
            challengeToUpdate.StartDate = Challenge.StartDate;
            challengeToUpdate.EndDate = Challenge.EndDate;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
