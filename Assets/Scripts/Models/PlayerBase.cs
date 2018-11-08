using Newtonsoft.Json;

namespace Models
{
    [JsonObject]
    public class PlayerBase
    {
        public int PlayerId { get; set; }
        public BaseBuilding Building1 { get; set; }
        public BaseBuilding Building2 { get; set; }
        public BaseBuilding Building3 { get; set; }
        public BaseBuilding Building4 { get; set; }
        public BaseBuilding Building5 { get; set; }
        public BaseBuilding Building6 { get; set; }
        public BaseBuilding Building7 { get; set; }
        public BaseBuilding Building8 { get; set; }
        public BaseBuilding Building9 { get; set; }
        public BaseBuilding Building10 { get; set; }
    }

}
