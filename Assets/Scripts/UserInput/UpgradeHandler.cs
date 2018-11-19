using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System;

namespace UserInput
{
    public class UpgradeHandler : MonoBehaviour
    {
        public void UpgradeShipSpeed()
        {
            Development.MockedAPI.UpgradeShipSpeed();
        }

        public void UpgradeShipArmor()
        {
            Development.MockedAPI.UpgradeShipArmor();
        }

        public void UpgradeShipDamage()
        {
            Development.MockedAPI.UpgradeShipDamage();
        }

        internal void UpgradeBuildingOnClick(BaseBuilding buildingData)
        {
            Debug.Log($"Updating building {buildingData.Name}");
        }
    }
}

