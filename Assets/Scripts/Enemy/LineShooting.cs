using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class LineShooting : MonoBehaviour
    {
        [Tooltip("Cooldown variable so that all the enemies can not shoot at the same time")]
        public float EnemyShotCooldown = 1.5f;
        [Tooltip("If enemies are allowed to shoot keep this true. Public variable atm because of debugging")]
        public bool EnemiesAllowedToShoot = true;

        public void SetEnemyShootingOnCooldown()
        {
            EnemiesAllowedToShoot = false;
            StartCoroutine(ResetShootingCooldown());
        }

        private IEnumerator ResetShootingCooldown()
        {
            yield return new WaitForSeconds(EnemyShotCooldown);
            EnemiesAllowedToShoot = true;
        }

    }
}

