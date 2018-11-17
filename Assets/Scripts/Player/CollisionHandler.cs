using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{

    public class CollisionHandler : MonoBehaviour
    {
        private PlayerStats _playerStats;

        private void Start()
        {
            _playerStats = GetComponent<PlayerStats>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Enemy")
            {
                int damage = collision.GetComponent<Enemy.EnemyStats>().Damage;
                _playerStats.ReducePlayerHp(damage);
            }
            else if(collision.tag == "EnemyProjectile")
            {
                _playerStats.DestroyPlayer();
            }
        }
    }
}
