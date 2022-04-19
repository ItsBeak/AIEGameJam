using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{

    public List<Upgrade> upgrades;

    public Transform upgradeParent;
    public GameObject upgradePrefab;



    private void Update()
    {
        foreach (Upgrade u in upgrades)
        {
            if (!u.purchased)
            {
                if (GameManager.MANAGER.tierManager.tiers[u.tierToUpgrade - 1].amountOwned > 0)
                {
                    if (u.prefabUI == null)
                    {
                        GameObject newUI;

                        newUI = Instantiate(upgradePrefab, upgradeParent);

                        newUI.GetComponent<UpgradeUI>().assignedUpgrade = u;
                        newUI.GetComponent<UpgradeUI>().icon.sprite = u.icon;

                        u.prefabUI = newUI;
                    }
                }
            }
        }
    }
}



[System.Serializable]
public class Upgrade
{
    public string upgradeName;
    public Sprite icon;

    public GameObject prefabUI;

    public int upgradeCost;
    public string description;

    public int tierToUpgrade;
    public float upgradeAmount;

    public bool purchased;
  
}
