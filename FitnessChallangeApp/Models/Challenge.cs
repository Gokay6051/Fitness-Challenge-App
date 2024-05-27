using System.ComponentModel.DataAnnotations;

namespace FitnessChallengeApp.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Difficulty { get; set; }

        public ICollection<UserChallenge>? UserChallenges { get; set; }
    }
}
