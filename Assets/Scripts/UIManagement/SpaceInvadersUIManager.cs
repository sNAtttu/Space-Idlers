using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UIManagement
{
    public class SpaceInvadersUIManager : MonoBehaviour
    {
        public static TextMeshProUGUI ScoreText;
        public int StartingScore = 0;
        // Use this for initialization
        void Start()
        {
            ScoreText = GameObject.FindGameObjectWithTag("ScoreText")
                .GetComponent<TextMeshProUGUI>();
            ScoreText.SetText(StartingScore.ToString());
        }

        public static void SetScoreText(int score)
        {
            ScoreText.SetText(score.ToString());
        }

    }

}

