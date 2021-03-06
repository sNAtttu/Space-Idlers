﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models
{
    [JsonObject]
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public int TimePlayed { get; set; }
        public bool SoundsOn { get; set; }
        public bool AudioOn { get; set; }
        public List<SpaceInvaderMatch> SpaceInvaderMatches { get; set; }
        public SpaceInvaderPlayerShip SpaceInvaderPlayerShip { get; set; }
        public PlayerBase PlayerBase { get; set; }

        public static implicit operator PlayerLocalData(Player playerData)
        {
            return new PlayerLocalData
            {
                id = playerData.Id,
                username = playerData.Name
            };
        }

    }
}

