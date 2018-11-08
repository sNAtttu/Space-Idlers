using Newtonsoft.Json;

namespace Models
{
    [JsonObject]
    public class SpaceInvaderMatch
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
    }
}

