using Newtonsoft.Json;

namespace Models
{
    [JsonObject]
    public class BaseBuilding
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public bool IsUnlocked { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int TimeOfProduction { get; set; }
        public int Multiplier { get; set; }
        public int Outcome { get; set; }
    }
}
