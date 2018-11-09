using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

namespace UserInput
{
    public class UpgradeHandler : MonoBehaviour
    {
        public void UpgradeBuildingOnClick(BaseBuilding building)
        {
            Debug.Log(building.Name);
        }
    }
}

