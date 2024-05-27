using Microsoft.AspNetCore.Identity;

namespace FitnessChallangeApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties can go here
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<UserChallenge> UserChallenges { get; set; }
    }

}
