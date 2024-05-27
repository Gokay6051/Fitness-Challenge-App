using FitnessChallengeApp.Data;
using FitnessChallengeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessChallengeApp.Pages
{
    [Authorize]
    public class BrowseChallengesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BrowseChallengesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Challenge> Challenges { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }

        [BindProperty(SupportsGet = true)]
        public string StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Difficulty { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Challenges.AsQueryable();

            if (!string.IsNullOrEmpty(Keyword))
            {
                query = query.Where(c => c.Title.Contains(Keyword) || c.Description.Contains(Keyword));
            }

            if (!string.IsNullOrEmpty(StartDate) && DateTime.TryParse(StartDate, out DateTime startDate))
            {
                query = query.Where(c => c.StartDate >= startDate);
            }

            if (!string.IsNullOrEmpty(EndDate) && DateTime.TryParse(EndDate, out DateTime endDate))
            {
                query = query.Where(c => c.EndDate <= endDate);
            }

            if (!string.IsNullOrEmpty(Difficulty))
            {
                query = query.Where(c => c.Difficulty == Difficulty);
            }

            Challenges = await query.OrderBy(c => c.Difficulty).ToListAsync();
        }
    }
}
