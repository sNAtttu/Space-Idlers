using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagement
{
    public class SpaceInvadersSpawnEnemies : MonoBehaviour
    {
        public int EnemiesInRow = 10;
        // TODO This should come from the API
        public int DifficultyLevel = 1;

        public Transform EnemiesParentObject;
        public GameObject enemyPrefab;

        private PlayMakerFSM sceneManagerFsm;
        private SpaceInvaderManager sceneManager;

        private void Start()
        {
            sceneManager = GetComponent<SpaceInvaderManager>();
            sceneManagerFsm = GetComponent<PlayMakerFSM>();
        }

        private void SpawnEnemies(int lineAmount)
        {
            Vector2 spawnPoint = new Vector2();
            float enemyWidth = enemyPrefab.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
            float enemyHeight = enemyPrefab.GetComponentInChildren<SpriteRenderer>().bounds.size.y;

            if(sceneManager.LevelEnemies == null)
            {
                sceneManager.LevelEnemies = new List<GameObject>();
            }

            for (int lines = 0; lines < lineAmount; lines++)
            {
                GameObject enemyLine = new GameObject { name = $"line_{lines}" };

                // TODO: Use difficulty level instead of number one defined in the variables
                AttachBehaviorScriptsToTheEnemyLine(enemyLine, DifficultyLevel);

                for (int enemyCount = 0; enemyCount < EnemiesInRow; enemyCount++)
                {
                    GameObject spawnedEnemy = Instantiate(enemyPrefab, enemyLine.transform);
                    spawnedEnemy.transform.localPosition = spawnPoint;
                    spawnedEnemy.GetComponent<ShootingEnemy>().SetShootingDifficulty(DifficultyLevel);
                    spawnPoint.x += enemyWidth;
                    sceneManager.LevelEnemies.Add(spawnedEnemy);
                }
                spawnPoint.x = 0;
                spawnPoint.y -= enemyHeight;
            }
            sceneManagerFsm.SendEvent("EnemiesSpawned");
        }

        private void AttachBehaviorScriptsToTheEnemyLine(GameObject enemyLine, int difficultyLevel)
        {
            EnemyMovement movementScript = enemyLine.AddComponent<EnemyMovement>();
            movementScript.MovementIntervalSeconds = (movementScript.MovementIntervalSeconds / difficultyLevel);
            enemyLine.transform.SetParent(EnemiesParentObject);
            enemyLine.transform.localPosition = new Vector3();

            LineShooting shootingRules = enemyLine.AddComponent<LineShooting>();
            shootingRules.EnemyShotCooldown = (shootingRules.EnemyShotCooldown / difficultyLevel);
        }
    }
}

