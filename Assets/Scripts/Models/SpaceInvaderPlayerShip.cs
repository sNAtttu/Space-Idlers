using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Models
{
    [JsonObject]
    public class SpaceInvaderPlayerShip
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Damage { get; set; }
        public int Hitpoints { get; set; }
        public int Speed { get; set; }
        public int Shield { get; set; }
        public int DamageUpgradePrice { get; set; }
        public int DamageUpgrade { get; set; }
        public int HitPointsUpgradePrice { get; set; }
        public int HitPointsUpgrade { get; set; }
        public int SpeedUpgradePrice { get; set; }
        public int SpeedUpgrade { get; set; }
        public int ShieldUpgradePrice { get; set; }
        public int ShieldUpgrade { get; set; }
    }

}
