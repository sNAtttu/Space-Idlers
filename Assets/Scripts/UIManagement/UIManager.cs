using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Utilities;

namespace UIManagement
{
    public class UIManager : MonoBehaviour
    {

        private PlayMakerFSM _uiFsm;

        private void Start()
        {
            _uiFsm = GetComponent<PlayMakerFSM>();
        }

        public void CheckIfUserExists()
        {
            User user = DataService.GetUser("sNAttu");
            if(user == null)
            {
                _uiFsm.SendEvent(Constants.UiConstants.NoUserEvent);
                return;
            }
            _uiFsm.SendEvent(Constants.UiConstants.UserExistsEvent);         
        }
    }
}

