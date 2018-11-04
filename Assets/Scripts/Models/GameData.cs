using Newtonsoft.Json;

namespace Models
{
    [JsonObject]
    public class GameData
    {
        [JsonProperty(PropertyName = "gameId")]
        public int GameId { get; set; }
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        public override string ToString()
        {
            return $"Game Id: {GameId}. Data: {Data}";
        }

    }
}

