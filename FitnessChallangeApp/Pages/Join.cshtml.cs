using FitnessChallengeApp.Data;
using FitnessChallengeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FitnessChallangeApp.Pages
{
    [Authorize]
    public class JoinModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public JoinModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            var challenge = await _context.Challenges.FindAsync(id);

            if (challenge == null)
            {
                return NotFound();
            }

            var userChallenge = new UserChallenge
            {
                User_Id = userId,
                ChallengeId = id
            };

            _context.UserChallenges.Add(userChallenge);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
