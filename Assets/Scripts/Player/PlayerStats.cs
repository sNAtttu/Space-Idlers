using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIManagement;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        public int HealthPoints = 3;
        public int BaseDamage = 1;

        private PlayMakerFSM _playerFSM;

        private void Start()
        {
            _playerFSM = GetComponent<PlayMakerFSM>();
            SpaceInvadersUIManager.SetPlayerHpText(HealthPoints);
        }

        internal void DestroyPlayer()
        {
            _playerFSM.SendEvent("Die");
        }

        public void ReducePlayerHp(int hpAmount)
        {
            HealthPoints -= hpAmount;
            if(HealthPoints <= 0)
            {
                DestroyPlayer();
            }
            else
            {
                SpaceInvadersUIManager.SetPlayerHpText(HealthPoints);
            }
        }

        public void SendPlayerDeadEventToSceneManager()
        {
            GameObject sceneManager = GameObject.FindGameObjectWithTag("SpaceInvaderManager");
            sceneManager.GetComponent<PlayMakerFSM>().SendEvent("PlayerDead");
        }

    }
}

