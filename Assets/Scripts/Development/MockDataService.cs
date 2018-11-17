using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Newtonsoft.Json;

namespace Development
{
    public static class MockDataService
    {

        private static SpaceInvaderPlayerShip CreateMockPlayerShip()
        {
            return new SpaceInvaderPlayerShip
            {
                Id = 0,
                PlayerId = 69,
                Damage = 1,
                DamageUpgrade = 1,
                DamageUpgradePrice = 10,
                Hitpoints = 3,
                HitPointsUpgrade = 1,
                HitPointsUpgradePrice = 20,
                Shield = 1,
                ShieldUpgrade = 2,
                ShieldUpgradePrice = 10,
                Speed = 1,
                SpeedUpgrade = 2,
                SpeedUpgradePrice = 100
            };
        }

        private static List<SpaceInvaderMatch> CreateMockPlayerMatches()
        {
            return new List<SpaceInvaderMatch>()
            {
                new SpaceInvaderMatch
                {
                    MatchId = 0,
                    PlayerId = 69
                },
                new SpaceInvaderMatch
                {
                    MatchId = 1,
                    PlayerId = 69
                }
            };
        }

        private static PlayerBase CreateMockPlayerBase()
        {

            List<BaseBuilding> buildings = new List<BaseBuilding>();

            List<string> buildingNames = new List<string>
            {
                "Hangar",
                "Armory",
                "Enginery",
                "Factory",
                "Machinery",
                "Barracks",
                "Workshop",
                "Canteen",
                "Runway",
                "Brothel"
            };

            for (int i = 0; i < 10; i++)
            {
                buildings.Add(new BaseBuilding
                {
                    BuildingId = i,
                    IsUnlocked = i <= 4 ? true : false,
                    Multiplier = 1,
                    Count = (10 - i),
                    Name = buildingNames[i],
                    Outcome = i * i,
                    Price = 10 * i,
                    TimeOfProduction = i + 1
                });
            }

            return new PlayerBase
            {
                PlayerId = 69,
                Building1 = buildings[0],
                Building2 = buildings[1],
                Building3 = buildings[2],
                Building4 = buildings[3],
                Building5 = buildings[4],
                Building6 = buildings[5],
                Building7 = buildings[6],
                Building8 = buildings[7],
                Building9 = buildings[8],
                Building10 = buildings[9],
            };
        }

        private static Models.Player CreateMockPlayer()
        {
            return new Models.Player
            {
                Id = System.Guid.NewGuid(),
                Money = 6000,
                Name = "Ankit",
                SoundsOn = true,
                TimePlayed = 0,
                AudioOn = true,
                PlayerBase = CreateMockPlayerBase(),
                SpaceInvaderMatches = CreateMockPlayerMatches(),
                SpaceInvaderPlayerShip = CreateMockPlayerShip()
            };
        }

        public static string GetPlayerData(int playerId)
        {
            Models.Player player = CreateMockPlayer();
            string playerAsJson = JsonConvert.SerializeObject(player);
            Debug.Log($"Loading data to the game: {playerAsJson}");
            return playerAsJson;
        }

    }

}
