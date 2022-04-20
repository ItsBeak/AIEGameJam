using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{

    public GameManager manager;
    public TierManager tiers;
    public UpgradeManager upgrades;


    public void Save()
    {

        string tempCoins = manager.coins.ToString("F6");
        PlayerPrefs.SetString("Coins", tempCoins);

        foreach (Tier t in tiers.tiers)
        {
            PlayerPrefs.SetInt(t.tierName + "Owned", t.amountOwned);
            PlayerPrefs.SetFloat(t.tierName + "UpgradeLevel", t.upgradeLevel);
        }

        foreach (Upgrade u in upgrades.upgrades)
        {
            PlayerPrefs.SetFloat(u.upgradeName + "Owned", (u.purchased ? 1 : 0));
        }


        PlayerPrefs.Save();
    }

    public void Load()
    {
        string tempCoins = PlayerPrefs.GetString("Coins");
        manager.coins = double.Parse(tempCoins, System.Globalization.CultureInfo.InvariantCulture);

        foreach (Tier t in tiers.tiers)
        {
            t.amountOwned = PlayerPrefs.GetInt(t.tierName + "Owned");
            t.upgradeLevel = PlayerPrefs.GetFloat(t.tierName + "UpgradeLevel");
        }

        foreach (Upgrade u in upgrades.upgrades)
        {
            u.purchased = ((PlayerPrefs.GetFloat(u.upgradeName + "Owned") == 1 ? true : false));
        }

    }

    public void ClearSaveData()
    {
        PlayerPrefs.DeleteAll();
    }

}
