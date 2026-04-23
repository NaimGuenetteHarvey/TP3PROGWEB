using System.Text.Json.Serialization;

namespace flappyBirdServeur.Models
{
    public class Scores
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public float Chrono { get; set; }
        public bool Visibilité { get; set; }
        public string Date { get; set; }
        public string? UserId { get; set; }

        [JsonIgnore]
      public virtual Users? User { get; set; }
    }
}
