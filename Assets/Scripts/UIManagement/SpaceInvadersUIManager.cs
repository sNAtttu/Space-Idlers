using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UIManagement
{
    public class SpaceInvadersUIManager : MonoBehaviour
    {
        public static TextMeshProUGUI PlayerHp;
        public static TextMeshProUGUI FortressHp;
        public static TextMeshProUGUI ScoreText;
        public int StartingScore = 0;

        // Use this for initialization
        void Start()
        {
            ScoreText = GameObject.FindGameObjectWithTag("ScoreText")
                .GetComponent<TextMeshProUGUI>();
            PlayerHp = GameObject.FindGameObjectWithTag("PlayerHpText")
                .GetComponent<TextMeshProUGUI>();
            FortressHp = GameObject.FindGameObjectWithTag("FortressHpText")
                .GetComponent<TextMeshProUGUI>();

            ScoreText.SetText(StartingScore.ToString());
        }

        public static void SetScoreText(int score)
        {
            ScoreText.SetText(score.ToString());
        }

        public static void SetPlayerHpText(int hp)
        {
            PlayerHp.SetText($"HP {hp.ToString()}");
        }

        public static void SetFortressHpText(int hp)
        {
            FortressHp.SetText($"Fortress HP {hp.ToString()}");
        }
    }

}

