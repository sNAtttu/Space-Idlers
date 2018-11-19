using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIManagement;

namespace SceneManagement
{
    public class SpaceInvadersScoreManager : MonoBehaviour
    {
        private int currentScore;
        public int CurrentScore
        {
            get
            {
                return currentScore;
            }

            set
            {
                currentScore = value;
                SpaceInvadersUIManager.SetScoreText(currentScore);
            }
        }

        public void UpdatePlayerScore()
        {
            Development.MockedAPI.IncrementPlayerMoneyAfterGame(CurrentScore);
        }

    }

}

