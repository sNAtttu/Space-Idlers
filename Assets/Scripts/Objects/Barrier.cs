using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Barrier : MonoBehaviour
    {
        public int BarrierHp = 3;

        private bool IsEnemy(Collider2D collision)
        {
            if(collision.tag == "FallingEnemy")
            {
                return true;
            }
            return false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Fireball")
            {
                int damage = collision.GetComponent<Shots.Fireball>().Damage;
                ReduceHp(damage);
                Destroy(collision.gameObject);
            }
            else if (IsEnemy(collision))
            {
                int damage = collision.GetComponent<Enemy.EnemyStats>().Damage;
                ReduceHp(damage);
                Destroy(collision.gameObject);
            }
            
        }

        private void DestroyBarrier()
        {
            Destroy(gameObject);
        }

        public void ReduceHp(int reduceAmount)
        {
            BarrierHp -= reduceAmount;
            if(BarrierHp <= 0)
            {
                DestroyBarrier();
            }
        }


    }
}

