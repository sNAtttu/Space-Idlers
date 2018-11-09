using UnityEngine.UI;
using UnityEngine;
using Models;
using DoozyUI;
using UnityEngine.Events;
using System.Collections;

namespace SceneManagement
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        public GameObject Building1Btn;

        private PlayMakerFSM sceneManagerFsm;

        delegate void buildingButtonHandler(int cooldown);

        private void Start()
        {
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
            BaseBuilding building1 = playerData.PlayerBase.Building1;
            PopulateButtonValues(Building1Btn, building1);
        }

        IEnumerator FillCooldownMeter(GameObject pressedButton, Image fillMeter, float cooldownSeconds)
        {
            pressedButton.GetComponentInParent<UIButton>().DisableButton();
            Debug.Log("Cooldown seconds: " + cooldownSeconds);
            float usedTime = 0;
            fillMeter.fillAmount = 0;
            while (usedTime < cooldownSeconds)
            {
                usedTime += Time.deltaTime;
                fillMeter.fillAmount = usedTime / cooldownSeconds;
                yield return new WaitForEndOfFrame();
            }
            pressedButton.GetComponentInParent<UIButton>().EnableButton();
        }

        private void PopulateButtonValues(GameObject button, BaseBuilding buildingData)
        {

            button.GetComponent<Button>().onClick.AddListener(() => 
            {
                // TODO: Find a better way to do this
                Transform fillMeter = button.transform.GetChild(2);
                Image fillMeterImage = fillMeter.GetComponent<Image>();
                if(fillMeterImage.type != Image.Type.Filled)
                {
                    Debug.LogError("Fill meter type is invalid");
                    return;
                }
                StartCoroutine(FillCooldownMeter(button, fillMeterImage, buildingData.TimeOfProduction));
            });

            Text buttonLabel = button.GetComponentInChildren<Text>();
            buttonLabel.text = buildingData.Name;

            sceneManagerFsm.SendEvent(Constants.MainMenuConstants.ButtonsPopulatedEvent);
        }

    }
}

