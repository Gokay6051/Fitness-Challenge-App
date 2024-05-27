using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessChallengeApp.Models
{
    public class UserChallenge
    {
        public int? Id { get; set; }
        public String User_Id { get; set; }
        public User? User { get; set; }

        public int ChallengeId { get; set; }
        public Challenge? Challenge { get; set; }

        public int? Progress { get; set; }
        /*
        public static implicit operator UserChallenge(UserChallenge v)
        {
            throw new NotImplementedException();
        }
        */
    }
}
