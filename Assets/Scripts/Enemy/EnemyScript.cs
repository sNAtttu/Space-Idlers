using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneManagement;
using System.Linq;

namespace Enemy
{
    public class EnemyScript : MonoBehaviour
    {
        public Animator EnemyAnimator;
        [Tooltip("This is the amount of score that player will get by killing this badass")]
        public int ScoreAmount = 10;

        private SpaceInvaderManager sceneManager;

        private void Start()
        {
            sceneManager = FindObjectOfType<SpaceInvaderManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Fireball":
                    AddPlayerScore(ScoreAmount);
                    HandleFireBallCollision(collision.gameObject);
                    break;
                case "RightBorder":
                    FindObjectsOfType<EnemyMovement>().ToList().ForEach(em => em.SetEnemyDirection(false));
                    break;
                case "LeftBorder":
                    FindObjectsOfType<EnemyMovement>().ToList().ForEach(em => em.SetEnemyDirection(true));
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
            sceneManager.RemoveLevelEnemy(gameObject);
            Destroy(fireBall);
            Destroy(EnemyAnimator.gameObject, 1f);
            Destroy(gameObject, 1f);
        }


    }

}

