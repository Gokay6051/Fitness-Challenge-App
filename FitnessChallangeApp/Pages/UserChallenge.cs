using System.ComponentModel.DataAnnotations;
using FitnessChallengeApp.Models;

namespace FitnessChallangeApp.Models
{
    public class UserChallenge
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ChallengeId { get; set; }

        public ApplicationUser User { get; set; }
        public Challenge Challenge { get; set; }
    }
}
