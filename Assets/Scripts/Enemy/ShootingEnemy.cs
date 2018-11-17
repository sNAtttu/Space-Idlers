using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class ShootingEnemy : MonoBehaviour
    {
        public GameObject EnemyProjectile;

        public float ShootingIntervalMin = 1.2f;
        public float ShootingIntervalMax = 5.0f;

        public bool EnemyShouldBeShooting = true;

        private void Start()
        {
            StartCoroutine(ShootProjectile());
        }

        IEnumerator ShootProjectile()
        {

            while (EnemyShouldBeShooting)
            {
                float waitTime = Random.Range(ShootingIntervalMin, ShootingIntervalMax);
                yield return new WaitForSeconds(waitTime);
                Instantiate(EnemyProjectile, transform.position, EnemyProjectile.transform.rotation);
            }

        }

    }
}
