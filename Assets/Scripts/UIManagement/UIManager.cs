using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Utilities;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;
using System;

namespace UIManagement
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI PlayerNameText;
        public TextMeshProUGUI PlayerMoneyText;
        public Text UsernameText;

        public bool UseMockedVersion = true;

        private PlayMakerFSM _uiFsm;

        private void Start()
        {
            _uiFsm = GetComponent<PlayMakerFSM>();
        }

        public void SetPlayerMoneyText(int money)
        {
            PlayerMoneyText.SetText($"Credit: {money.ToString()}");
        }

        private void InitializePlayerDataToUi(Models.Player user)
        {
            SetPlayerMoneyText(user.Money);
            PlayerNameText.SetText(user.Name);
        }

        public void SaveUserData()
        {
            try
            {
                string username = UsernameText.text;
                Models.Player savedPlayer = DataService.CreateUser(username);
                DataService.SavePlayerDataLocally(savedPlayer);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to save player data");
                throw e;
            }
        }

        public void GetUserData()
        {
            if (UseMockedVersion)
            {
                string jsonPlayer = Development.MockDataService.GetPlayerData(69);

                Models.Player user = JsonConvert.DeserializeObject<Models.Player>(jsonPlayer);

                if (user == null)
                {
                    _uiFsm.SendEvent(Constants.UiConstants.NoUserEvent);
                    return;
                }
                Debug.Log($"User {user.Name} loaded!");
                SceneManagement.MainMenuDataCache.PlayerData = user;
                _uiFsm.SendEvent(Constants.UiConstants.UserExistsEvent);
                InitializePlayerDataToUi(user);
            }

        }
    }
}

