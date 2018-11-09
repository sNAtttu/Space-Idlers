using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Utilities;
using Newtonsoft.Json;
using TMPro;

namespace UIManagement
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI PlayerNameText;
        public TextMeshProUGUI PlayerMoneyText;

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
            SceneManagement.MainMenuDataCache.PlayerData = user;
            _uiFsm.SendEvent(Constants.UiConstants.UserExistsEvent);
            InitializePlayerDataToUi(user);
        }
    }
}

