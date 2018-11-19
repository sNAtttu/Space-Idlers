using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagement
{
    public class SpaceInvaderManager : MonoBehaviour
    {
        public List<GameObject> LevelEnemies;

        public GameObject PlayerPrefab;
        public GameObject FortressPrefab;
        public List<GameObject> EnemyPrefabs;
        public List<Transform> EnemySpawningPoints;
        public Vector2 PlayerSpawnPosition = new Vector2(0, -4.5f);
        public Vector2 FortressSpawnPosition = new Vector2(0, -4.7f);
        public float RespawnInterval = 1.0f;
        public bool ShouldSpawnEnemies = true;
        public bool ShouldSpawnFortress = false;
        private PlayMakerFSM sceneManager;

        private void Start()
        {
            sceneManager = GetComponent<PlayMakerFSM>();
            StartCoroutine(SpawnEnemy());
        }

        public void SpawnPlayer()
        {
            GameObject player = Instantiate(PlayerPrefab, PlayerSpawnPosition, PlayerPrefab.transform.rotation);
            player.GetComponent<Player.Movement>().Speed += MainMenuDataCache.PlayerData.SpaceInvaderPlayerShip.Speed;
        }

        public void SpawnFortress()
        {
            if (ShouldSpawnFortress)
            {
                Instantiate(FortressPrefab, FortressSpawnPosition, FortressPrefab.transform.rotation);
            }

        }

        private void SpawnRandomEnemy()
        {
            Transform spawnPosition = EnemySpawningPoints[Random.Range(0, (EnemySpawningPoints.Count - 1))];
            GameObject enemyToSpawn = EnemyPrefabs[Random.Range(0, (EnemyPrefabs.Count - 1))];
            Instantiate(enemyToSpawn, spawnPosition.position, enemyToSpawn.transform.rotation);
        }

        IEnumerator SpawnEnemy()
        {
            while (ShouldSpawnEnemies)
            {
                SpawnRandomEnemy();
                yield return new WaitForSeconds(RespawnInterval);
            }
        }

        public void RemoveLevelEnemy(GameObject enemyObject)
        {
            LevelEnemies.Remove(enemyObject);
            if(LevelEnemies.Count == 0)
            {
                sceneManager.SendEvent("EnemiesDestroyed");
            }
        }

    }
}


