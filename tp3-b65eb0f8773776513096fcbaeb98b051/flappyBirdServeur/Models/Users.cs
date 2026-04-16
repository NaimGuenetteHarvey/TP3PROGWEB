using Microsoft.AspNetCore.Identity;

namespace flappyBirdServeur.Models
{
    public class Users: IdentityUser
    {
     public virtual List<Scores> Scores { get; set; } = new List<Scores>();
    }
}
