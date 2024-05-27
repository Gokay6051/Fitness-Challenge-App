using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessChallengeApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        public string Bio { get; set; }

        public ICollection<UserChallenge>? UserChallenges { get; set; }
        //ublic object Identity { get; internal set; }
    }
}
