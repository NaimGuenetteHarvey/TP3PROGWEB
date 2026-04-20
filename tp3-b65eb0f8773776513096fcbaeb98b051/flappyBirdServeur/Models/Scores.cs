using System.Text.Json.Serialization;

namespace flappyBirdServeur.Models
{
    public class Scores
    {
      public int Id { get; set; }
      public int Points { get; set; }
      public bool IsPublic { get; set; }
      public string? UserId { get; set; }
      [JsonIgnore]
      public virtual List<Users> Users { get; set; } = new List<Users>();
    }
}
