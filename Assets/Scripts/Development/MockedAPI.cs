using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Development
{
    public class MockedAPI
    {
        public static void IncrementPlayerMoneyAfterGame(int moneyAmount)
        {
            SceneManagement.MainMenuDataCache.PlayerData.Money += moneyAmount;
        }
    }
}

