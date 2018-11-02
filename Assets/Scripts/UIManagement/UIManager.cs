using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Utilities;

namespace UIManagement
{
    public class UIManager : MonoBehaviour
    {

        private PlayMakerFSM UiFsm;

        private void Start()
        {
            UiFsm = GetComponent<PlayMakerFSM>();
        }

        public void CheckIfUserExists()
        {
            User user = DataService.GetUser("sNAttu");
            if(user == null)
            {
                UiFsm.SendEvent(Constants.UiConstants.NoUserEvent);
                return;
            }
            UiFsm.SendEvent(Constants.UiConstants.UserExistsEvent);         
        }
    }
}

