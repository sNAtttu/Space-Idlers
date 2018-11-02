using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagement
{
    public class SpaceInvaderManager : MonoBehaviour
    {
        public GameObject PlayerPrefab;

        public void SpawnPlayer()
        {
            Instantiate(PlayerPrefab, new Vector2(0, -4.5f), PlayerPrefab.transform.rotation);
        }

    }
}


