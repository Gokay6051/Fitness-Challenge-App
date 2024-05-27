using FitnessChallangeApp.Models;
using FitnessChallengeApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FitnessChallengeApp.Pages
{
    [Authorize]
    public class UserChallengesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserChallengesModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Models.UserChallenge> UserChallenges { get; set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            UserChallenges = await _context.UserChallenges
                .Include(uc => uc.Challenge)
                .Where(uc => uc.User_Id == userId)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            var userChallenge = await _context.UserChallenges
                .FirstOrDefaultAsync(uc => uc.Id == id && uc.User_Id == userId);

            if (userChallenge == null)
            {
                return NotFound();
            }

            _context.UserChallenges.Remove(userChallenge);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
