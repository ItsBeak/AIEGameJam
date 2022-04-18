using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{

    public List<Upgrade> upgrades;

    public Transform upgradeParent;
    public GameObject upgradePrefab;

    private void Start()
    {
        foreach (Upgrade u in upgrades)
        {
            GameObject newUpgrade;

            newUpgrade = Instantiate(upgradePrefab, upgradeParent);

            newUpgrade.GetComponent<UpgradeUI>().assignedUpgrade = u;
            newUpgrade.GetComponent<UpgradeUI>().icon.sprite = u.icon;

        }
    }

}

[System.Serializable]
public class Upgrade
{
    public string upgradeName;
    public Sprite icon;

    public int upgradeCost;
    public string description;

    public int tierToUpgrade;
    public float upgradeAmount;
  
}
