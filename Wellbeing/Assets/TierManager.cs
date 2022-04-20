using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TierManager : MonoBehaviour
{

    public List<Tier> tiers;

    public Transform tierParent;
    public GameObject tierPrefab;

    float timer;

    float coinModifier;

    private void Start()
    {
        foreach (Tier t in tiers)
        {
            GameObject newTier;

            newTier = Instantiate(tierPrefab, tierParent);

            newTier.GetComponent<TierUI>().assignedTier = t;
            newTier.GetComponent<TierUI>().icon.sprite = t.icon;

        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;

            foreach (Tier t in tiers)
            {
                coinModifier += ((t.amountOwned * (1 * t.modifierPerTier)));

                if (t.upgradeLevel != 0)
                {
                    coinModifier *= t.upgradeLevel;
                }

            }

            GameManager.MANAGER.GenerateCoin(coinModifier);

            coinModifier = 0;

        }

    }
}

[System.Serializable]
public class Tier
{
    public string tierName;
    public Sprite icon;

    public float baseCost;
    public string description;

    [HideInInspector]
    public float cost;
    public float inflationAmount;   

    [HideInInspector]
    public int amountOwned;
    public float modifierPerTier;

    public float upgradeLevel;

}
