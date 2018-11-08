using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Utilities;
using Newtonsoft.Json;

namespace UIManagement
{
    public class UIManager : MonoBehaviour
    {

        private PlayMakerFSM _uiFsm;

        private void Start()
        {
            _uiFsm = GetComponent<PlayMakerFSM>();
        }

        public void GetUserData()
        {
            string jsonPlayer = Development.MockDataService.GetPlayerData(69);

            Models.Player user = JsonConvert.DeserializeObject<Models.Player>(jsonPlayer);

            Debug.Log($"User {user.Name} loaded!");

            if (user == null)
            {
                _uiFsm.SendEvent(Constants.UiConstants.NoUserEvent);
                return;
            }
            _uiFsm.SendEvent(Constants.UiConstants.UserExistsEvent);         
        }
    }
}

