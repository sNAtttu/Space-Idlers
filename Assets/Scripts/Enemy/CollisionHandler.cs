using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class CollisionHandler : MonoBehaviour
    {

        public Animator EnemyAnimator;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Fireball":
                    HandleFireBallCollision(collision.gameObject);
                    break;
                default:
                    break;
            }
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

