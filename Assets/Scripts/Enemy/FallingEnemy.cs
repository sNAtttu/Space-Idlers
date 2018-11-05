using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneManagement;

namespace Enemy
{
    public class FallingEnemy : MonoBehaviour
    {
        public Animator EnemyAnimator;
        [Tooltip("This is the amount of score that player will get by killing this badass")]
        public int ScoreAmount = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Fireball":
                    AddPlayerScore(ScoreAmount);
                    HandleFireBallCollision(collision.gameObject);
                    break;
                default:
                    break;
            }
        }

        private void AddPlayerScore(int amount)
        {
            FindObjectOfType<SpaceInvadersScoreManager>().CurrentScore += amount;
        }

        private void HandleFireBallCollision(GameObject fireBall)
        {
            EnemyAnimator.SetTrigger(Constants.EnemyConstants.DieEvent);
            GetComponent<AudioSource>().Play();
            Destroy(fireBall);
            Destroy(EnemyAnimator.gameObject, 1f);
            Destroy(gameObject, 1f);
        }


    }

}

