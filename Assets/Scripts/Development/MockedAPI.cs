using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Development
{
    public class MockedAPI
    {
        public static void IncrementPlayerMoneyAfterGame(int moneyAmount)
        {
            Debug.Log($"Player got {moneyAmount} credits");
            SceneManagement.MainMenuDataCache.PlayerData.Money += moneyAmount;
        }

        internal static void UpgradeShipArmor()
        {
            Debug.Log($"Upgrade player speed to next level");
            SceneManagement.MainMenuDataCache.PlayerData.SpaceInvaderPlayerShip.Shield += 1;
        }

        internal static void UpgradeShipDamage()
        {
            Debug.Log($"Upgrade player damage to next level");
            SceneManagement.MainMenuDataCache.PlayerData.SpaceInvaderPlayerShip.Damage += 1;
        }

        internal static void UpgradeShipSpeed()
        {
            Debug.Log($"Upgrade player speed to next level");
            SceneManagement.MainMenuDataCache.PlayerData.SpaceInvaderPlayerShip.Speed += 1;
        }
    }
}

