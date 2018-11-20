using Shots;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class ShootingEnemy : MonoBehaviour
    {
        public GameObject EnemyProjectile;

        // Shooting interval is based on random number between min and max
        public float ShootingIntervalMin = 1.2f;
        public float ShootingIntervalMax = 5.0f;
        // So that it doesn't feel that all aliens are shooting at the same time
        // These variables are introduced
        public float FirstShotMin = 5.0f;
        public float FirstShotMax = 15.0f;

        public float EnemyProjectileSpeed = 0.5f;

        public bool EnemyShouldBeShooting = true;

        private LineShooting lineShooting;

        private void Start()
        {
            lineShooting = GetComponentInParent<LineShooting>();
            if(lineShooting == null)
            {
                throw new System.Exception("Line shooting rules cannot be found");
            }
            StartCoroutine(StartShooting(Random.Range(FirstShotMin, FirstShotMax)));
        }

        public void SetShootingDifficulty(int difficultyLevel)
        {
            ShootingIntervalMin = (ShootingIntervalMin / difficultyLevel);
            ShootingIntervalMax = (ShootingIntervalMax / difficultyLevel);

            EnemyProjectileSpeed += (difficultyLevel / 10);

        }

        IEnumerator StartShooting(float waitTimeBeforeFirstShot)
        {
            yield return new WaitForSeconds(waitTimeBeforeFirstShot);
            StartCoroutine(ShootProjectile());
        }

        IEnumerator ShootProjectile()
        {

            while (EnemyShouldBeShooting)
            {
                float waitTime = Random.Range(ShootingIntervalMin, ShootingIntervalMax);
                yield return new WaitForSeconds(waitTime);
                if (lineShooting.EnemiesAllowedToShoot)
                {
                    GameObject projectile = Instantiate(EnemyProjectile, transform.position, EnemyProjectile.transform.rotation);
                    projectile.GetComponent<Fireball>().Speed = EnemyProjectileSpeed;
                    lineShooting.SetEnemyShootingOnCooldown();
                }

            }

        }

    }
}
