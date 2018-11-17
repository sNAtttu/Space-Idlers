using UnityEngine.UI;
using UnityEngine;
using Models;
using DoozyUI;
using System.Collections;
using System.Collections.Generic;
using UserInput;
using TMPro;
using UIManagement;

namespace SceneManagement
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        public GameObject Building1Btn;
        public GameObject Building2Btn;
        public GameObject Building3Btn;
        public GameObject Building4Btn;
        public GameObject Building5Btn;
        public GameObject Building6Btn;
        public GameObject Building7Btn;
        public GameObject Building8Btn;
        public GameObject Building9Btn;
        public GameObject Building10Btn;


        private Dictionary<GameObject, BaseBuilding> buildingsAndButtons;
        private PlayMakerFSM sceneManagerFsm;
        private UpgradeHandler upgradeHandler;

        
        private void Start()
        {
            upgradeHandler = GetComponent<UpgradeHandler>();
            sceneManagerFsm = GetComponent<PlayMakerFSM>();
        }

        public void InitializeScreen()
        {
            Models.Player playerData = MainMenuDataCache.PlayerData;
            if(playerData == null || playerData.PlayerBase == null)
            {
                Debug.LogError("Player base missing");
                throw new System.ArgumentNullException("Player base missing!");
            }

            buildingsAndButtons = new Dictionary<GameObject, BaseBuilding>();

            // TODO: When I'm not tired. Do this in more maintainable way. Thanks future Santeri. :D
            buildingsAndButtons.Add(Building1Btn, playerData.PlayerBase.Building1);
            buildingsAndButtons.Add(Building2Btn, playerData.PlayerBase.Building2);
            buildingsAndButtons.Add(Building3Btn, playerData.PlayerBase.Building3);
            buildingsAndButtons.Add(Building4Btn, playerData.PlayerBase.Building4);
            buildingsAndButtons.Add(Building5Btn, playerData.PlayerBase.Building5);
            buildingsAndButtons.Add(Building6Btn, playerData.PlayerBase.Building6);
            buildingsAndButtons.Add(Building7Btn, playerData.PlayerBase.Building7);
            buildingsAndButtons.Add(Building8Btn, playerData.PlayerBase.Building8);
            buildingsAndButtons.Add(Building9Btn, playerData.PlayerBase.Building9);
            buildingsAndButtons.Add(Building10Btn, playerData.PlayerBase.Building10);

            foreach (KeyValuePair<GameObject, BaseBuilding> entry in buildingsAndButtons)
            {
                PopulateButtonValues(entry.Key, entry.Value);
            }
        }

        IEnumerator FillCooldownMeter(GameObject pressedButton, Image fillMeter, float cooldownSeconds)
        {
            pressedButton.GetComponent<UIButton>().DisableButton();
            Debug.Log("Cooldown seconds: " + cooldownSeconds);
            float usedTime = 0;
            fillMeter.fillAmount = 0;
            while (usedTime < cooldownSeconds)
            {
                usedTime += Time.deltaTime;
                fillMeter.fillAmount = usedTime / cooldownSeconds;
                yield return new WaitForEndOfFrame();
            }
            pressedButton.GetComponent<UIButton>().EnableButton();
        }

        private void PopulateButtonValues(GameObject button, BaseBuilding buildingData)
        {

            button.GetComponent<Button>().onClick.AddListener(() => 
            {
                GameObject fillMeter = button.GetComponent<ButtonComponents>().FillMeter;
                Image fillMeterImage = fillMeter.GetComponent<Image>();
                if(fillMeterImage.type != Image.Type.Filled)
                {
                    Debug.LogError("Fill meter image type is invalid");
                    return;
                }
                upgradeHandler.UpgradeBuildingOnClick(buildingData);
                StartCoroutine(FillCooldownMeter(button, fillMeterImage, buildingData.TimeOfProduction));
            });

            Text buttonLabel = button.GetComponentInChildren<Text>();
            buttonLabel.text = buildingData.Name;

            TextMeshProUGUI costText = button.GetComponent<ButtonComponents>().UpgradeCost.GetComponentInChildren<TextMeshProUGUI>();

            costText.SetText(buildingData.Price.ToString());

            

            // Last thing to do is to disable button if it's not unlocked yet
            if (!buildingData.IsUnlocked)
            {
                button.GetComponent<UIButton>().DisableButton();
            }

        }

    }
}

