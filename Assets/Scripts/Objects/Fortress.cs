using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIManagement;

namespace Objects
{
    public class Fortress : MonoBehaviour
    {
        public int FortressHp = 10;

        private void Start()
        {
            SpaceInvadersUIManager.SetFortressHpText(FortressHp);
        }

        public void ReduceFortressHP(int hpAmount)
        {
            FortressHp -= hpAmount;
            if (FortressHp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                SpaceInvadersUIManager.SetFortressHpText(FortressHp);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Enemy")
            {
                int damage = collision.GetComponent<Enemy.EnemyStats>().Damage;
                ReduceFortressHP(damage);
            }
        }

    }
}

